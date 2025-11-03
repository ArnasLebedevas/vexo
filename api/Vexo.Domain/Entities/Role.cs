using Microsoft.AspNetCore.Identity;
using Vexo.Domain.Enums;

namespace Vexo.Domain.Entities;

public class Role(UserRole roleType) : IdentityRole<Guid>(roleType.ToString())
{
    public UserRole RoleType { get; set; } = roleType;
}