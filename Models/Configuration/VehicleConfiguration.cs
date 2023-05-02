using CelilCavus.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelilCavus.Models.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x=>x.Type).HasMaxLength(50);
            builder.Property(x=>x.Type).IsRequired();

            builder.Property(x=>x.Model).HasMaxLength(50);
            builder.Property(x=>x.Model).IsRequired();


            builder.Property(x=>x.Color).HasMaxLength(50);
            builder.Property(x=>x.Color).IsRequired();

            builder.HasOne(x=>x.Customers).WithOne(x=>x.Vehicle).HasForeignKey<Vehicle>(x=>x.CustomerId);
            
        }
    }
}