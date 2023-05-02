using CelilCavus.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelilCavus.Models.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x=>x.Name).HasMaxLength(50);
            builder.Property(x=>x.Name).IsRequired();

            builder.Property(x=>x.Age).IsRequired();

            builder.Property(x=>x.HouseType).HasMaxLength(50);
            builder.Property(x=>x.HouseType).IsRequired();

            builder.Property(x=>x.City).HasMaxLength(50);
            builder.Property(x=>x.City).IsRequired();

            builder.HasOne(x=>x.Order).WithOne(b=>b.Customer).HasForeignKey<Order>(x=>x.CustomerId);
        }
    }
}