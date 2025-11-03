using Microsoft.AspNetCore.Identity;
using Vexo.Application.Interfaces.Services;
using Vexo.Domain.Entities;

namespace Vexo.Infrastructure.Services;

public sealed class UserService(UserManager<User> userManager) : IUserService
{
    public async Task<User?> FindByEmailAsync(string email) => await userManager.FindByEmailAsync(email);

    public async Task<bool> CheckPasswordAsync(User user, string password) => await userManager.CheckPasswordAsync(user, password);

    public async Task<IdentityResult> CreateUserAsync(User user, string password) => await userManager.CreateAsync(user, password);
}