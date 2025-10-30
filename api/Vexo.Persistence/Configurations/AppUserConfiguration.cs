using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexo.Domain.Entities;

namespace Vexo.Persistence.Configurations;

internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasIndex(u => u.NormalizedEmail).IsUnique();

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(u => u.NormalizedEmail)
            .IsRequired()
            .HasMaxLength(256);
    }
}
