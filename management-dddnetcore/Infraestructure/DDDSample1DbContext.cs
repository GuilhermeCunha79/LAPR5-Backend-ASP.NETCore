using DDDNetCore.Domain.Warehouses;
using Microsoft.EntityFrameworkCore;
using DDDSample1.Infrastructure.Delivery;
using DDDSample1.Infrastructure.Warehouses;

namespace DDDSample1.Infrastructure
{
    public class DDDSample1DbContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Domain.Delivery.Delivery> Deliveries { get; set; }

        public DDDSample1DbContext(DbContextOptions options) : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(
        //         @"jdbc:mysql://vs285.dei.isep.ipp.pt:3306/");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryEntityTypeConfiguration());
        }
    }
}