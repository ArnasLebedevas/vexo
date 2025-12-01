using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexo.Domain.Entities;

namespace Vexo.Persistence.Configurations;

internal sealed class LoginCodeConfiguration : IEntityTypeConfiguration<LoginCode>
{
    public void Configure(EntityTypeBuilder<LoginCode> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.UserId, x.Code });
        builder.HasIndex(x => x.ExpiresAt);

        builder.Property(x => x.UserId)
             .IsRequired();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(6);

        builder.Property(x => x.ExpiresAt)
            .IsRequired();

        builder.Property(x => x.Used)
            .IsRequired();
    }
}
