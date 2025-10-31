using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexo.Domain.Entities;

namespace Vexo.Persistence.Configurations;

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.Token)
               .HasMaxLength(128)
               .IsRequired();

        builder.Property(rt => rt.ReplacedByToken)
               .HasMaxLength(128)
               .IsRequired(false);

        builder.HasIndex(rt => rt.Token).IsUnique();
        builder.HasIndex(rt => rt.AppUserId);
        builder.HasIndex(rt => new { rt.Token, rt.IsRevoked });

        builder.HasOne(rt => rt.AppUser)
               .WithMany(u => u.RefreshTokens)
               .HasForeignKey(rt => rt.AppUserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
