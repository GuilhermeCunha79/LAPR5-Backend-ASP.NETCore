using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.Delivery
{
    internal class DeliveryEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Delivery.Delivery>
    {
        public void Configure(EntityTypeBuilder<Domain.Delivery.Delivery> builder)
        {
            //builder.ToTable("Warehouses", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.DeliveryId);
            builder.OwnsOne(b => b.DeliveryDate);
            builder.OwnsOne(b => b.DeliveryMass);
            builder.OwnsOne(b => b.WarehouseId);
            builder.OwnsOne(b => b.DeliveryTime);
            //missing warehouse
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}