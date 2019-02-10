using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataLayer.DataContext
{

	//it is used for migration
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext (string[] args)
		{

			//var basePath = Directory.GetCurrentDirectory();
			//var configuration = new ConfigurationBuilder()
			//                        .SetBasePath(basePath)
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

			var connectionString = configuration
				.GetConnectionString("DefaultConnection");

			builder.UseSqlServer(connectionString);
			
			
			return new ApplicationDbContext(builder.Options);
		}
	}
}