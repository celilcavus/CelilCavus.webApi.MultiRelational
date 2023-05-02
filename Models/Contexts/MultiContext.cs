using CelilCavus.Entitys;
using CelilCavus.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CelilCavus.Models.Contexts
{
    public class MultiContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProducConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFCoreWepApi_MultiContext;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}