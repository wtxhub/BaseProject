using DataLayer.Configurations;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataContext
{
	public class ApplicationDbContext : DbContext
    {
		
        public ApplicationDbContext() : base() {}
        public ApplicationDbContext(DbContextOptions options) : base(options) { }



		//database sets woull be here
        public virtual DbSet<Company> Companies { set; get; }


		//fluient APIs
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // it should be placed here, otherwise it will rewrite the following settings!
            base.OnModelCreating(builder);

            // Custom application mappings
            builder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}