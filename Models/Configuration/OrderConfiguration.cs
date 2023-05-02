using CelilCavus.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelilCavus.Models.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x=>x.Time).HasDefaultValueSql("getdate()");

            builder.HasOne(x=>x.Product).WithOne(x=>x.Order).HasForeignKey<Product>(x=>x.OrderId);
        }
    }
}