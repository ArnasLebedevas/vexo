using Microsoft.AspNetCore.Identity;
using Vexo.Application.Interfaces.Services;
using Vexo.Domain.Entities;

namespace Vexo.Infrastructure.Services.Identity;

public sealed class IdentityUserService(UserManager<AppUser> userManager) : IUserService
{
    public async Task<AppUser?> FindByEmailAsync(string email) => await userManager.FindByEmailAsync(email);

    public async Task<bool> CheckPasswordAsync(AppUser user, string password) => await userManager.CheckPasswordAsync(user, password);
}