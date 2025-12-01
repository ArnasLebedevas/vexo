using Microsoft.AspNetCore.Identity;
using Vexo.Application.Interfaces.Services;
using Vexo.Domain.Entities;

namespace Vexo.Infrastructure.Identity;

public sealed class UserService(UserManager<User> userManager) : IUserService
{
    public Task<User?> GetByEmailAsync(string email) => userManager.FindByEmailAsync(email);

    public Task<bool> CheckPasswordAsync(User user, string password) => userManager.CheckPasswordAsync(user, password);

    public Task<string> GenerateEmailConfirmationTokenAsync(User user) => userManager.GenerateEmailConfirmationTokenAsync(user);

    public Task<IdentityResult> CreateUserAsync(User user) => userManager.CreateAsync(user);
}