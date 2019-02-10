using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DataLayer.DataContext
{
	public interface IContextFactory
	{
		T CreateContext<T> (string connectionString) where T : DbContext, new();
	}


	public class ContextFactory : IContextFactory
	{
		private IConfigurationRoot Configuration { set; get; }

		public ContextFactory ()
		{
		}

		public T CreateContext<T> (string connectionString) where T : DbContext, new()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appSettings.json", reloadOnChange: true, optional: false);

			Configuration = builder.Build();

			var appSettingRecord = "data:connectionString:" + connectionString;
			var con = Configuration[appSettingRecord];

			var optionsBuilder = new DbContextOptionsBuilder<T>();
			optionsBuilder.UseSqlServer(con);

			var instance = Activator.CreateInstance(typeof(T), new object[] { optionsBuilder.Options });
			return instance as T;
		}
	}
}
