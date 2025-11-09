using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexo.Domain.Entities;
using Vexo.Persistence.SeedData;

namespace Vexo.Persistence.Configurations;

internal sealed class AppRoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r => r.RoleType)
                .HasConversion<string>()
                .IsRequired();

        builder.Property(r => r.NormalizedName)
               .IsRequired()
               .HasMaxLength(256);

        builder.HasData(RoleSeedData.GetSeedData());
    }
}
