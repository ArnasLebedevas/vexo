using Vexo.Domain.Entities;
using Vexo.Domain.Enums;

namespace Vexo.Persistence.SeedData;

internal static class RoleSeedData
{
    public static IEnumerable<Role> GetSeedData() =>
    [
        new Role(UserRole.User)
        {
            Id = RoleIds.User,
            NormalizedName = nameof(UserRole.User).ToUpperInvariant()
        },
        new Role(UserRole.Admin)
        {
            Id = RoleIds.Admin,
            NormalizedName = nameof(UserRole.Admin).ToUpperInvariant()
        }
    ];
}