using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                .ToTable("Vehicles");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Model)
                .HasColumnType("varchar(500)");

            builder
                .Property(e => e.Manufacture)
                .HasColumnType("varchar(500)");

            builder
                .Property(e => e.Value)
                .IsRequired()
                .HasColumnType("decimal(18,4)");
        }
    }
}
