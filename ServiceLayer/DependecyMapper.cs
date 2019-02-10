using DataLayer.DataContext;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ServiceLayer
{
	public static class DependecyMapper
	{
		public static IServiceCollection AddBusinessServices (this IServiceCollection services)
		{

			var assm = typeof(DependecyMapper).Assembly;

			//repositories
			var repoSet =
					 from type in assm.GetExportedTypes()
					 where type.Namespace.EndsWith("ServiceLayer.Manager")
					 where type.GetInterfaces().Any()
					 select new { Service = type.GetInterfaces().Single(), Implementation = type };


			foreach (var reg in repoSet)
				services.AddScoped(reg.Service, reg.Implementation);

			return services;

		}


		public static IServiceCollection AddDataServices (this IServiceCollection services)
		{
			
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IContextFactory, ContextFactory>();

			var assm = typeof(IUnitOfWork).Assembly;

			//repositories
			var repoSet =
					 from type in assm.GetExportedTypes()
					 where type.Namespace.EndsWith("DataLayer.Repository")
					 where type.GetInterfaces().Any()
					 select new { Service = type.GetInterfaces().Single(), Implementation = type };


			foreach (var reg in repoSet)
				services.AddScoped(reg.Service, reg.Implementation);


			return services;

		}


	}


}


