using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
			builder.HasKey(e => e.Id);
			builder.Property(e => e.RowVersion).IsConcurrencyToken();
			builder.Property(e => e.Name).IsRequired();
        }
    }
}