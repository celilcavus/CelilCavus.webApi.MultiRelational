using CelilCavus.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelilCavus.Models.Configuration
{
    public class ProducConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x=>x.Quantiity).HasMaxLength(100);
            builder.Property(x=>x.Quantiity).IsRequired();

            builder.Property(x=>x.Price).HasColumnName("decimal(10,2)");
            builder.Property(x=>x.Price).IsRequired();

            
        }
    }
}