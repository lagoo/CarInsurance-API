using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class InsuredConfiguration : IEntityTypeConfiguration<Insured>
    {
        public void Configure(EntityTypeBuilder<Insured> builder)
        {
            builder
                .ToTable("Insureds");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasColumnType("varchar(500)");

            builder
                .Property(e => e.CPF)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder
                .HasIndex(e => e.CPF)
                .IsUnique();
        }
    }
}
