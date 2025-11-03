using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexo.Domain.Entities;
using Vexo.Domain.Enums;

namespace Vexo.Persistence.Configurations;

internal sealed class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.Property(r => r.RoleType)
                .HasConversion<string>()
                .IsRequired();

        builder.HasData(Enum.GetValues<UserRole>().Select(role => new AppRole(role)
        {
            Id = Guid.NewGuid(),
            NormalizedName = role.ToString().ToUpper()
        }));
    }
}
