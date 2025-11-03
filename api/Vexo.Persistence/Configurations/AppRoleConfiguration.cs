using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexo.Domain.Entities;
using Vexo.Domain.Enums;

namespace Vexo.Persistence.Configurations;

internal sealed class AppRoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r => r.RoleType)
                .HasConversion<string>()
                .IsRequired();

        builder.HasData(Enum.GetValues<UserRole>().Select(role => new Role(role)
        {
            Id = Guid.NewGuid(),
            NormalizedName = role.ToString().ToUpper()
        }));
    }
}
