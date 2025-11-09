using Microsoft.AspNetCore.Identity;
using Vexo.Application.Interfaces.Services;
using Vexo.Domain.Entities;

namespace Vexo.Infrastructure.Services;

public sealed class UserService(UserManager<User> userManager) : IUserService
{
    public Task<User?> FindByEmailAsync(string email) => userManager.FindByEmailAsync(email);

    public Task<bool> CheckPasswordAsync(User user, string password) => userManager.CheckPasswordAsync(user, password);

    public Task<IdentityResult> CreateUserAsync(User user, string? password = null) => userManager.CreateAsync(user, password ?? string.Empty);
}