using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder
                .ToTable("Insurances");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Value)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            builder
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Insurances)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Insured)
                .WithMany(e => e.Insurances)
                .HasForeignKey(e => e.InsuredId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
