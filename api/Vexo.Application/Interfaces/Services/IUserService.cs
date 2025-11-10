using Microsoft.AspNetCore.Identity;
using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Services;

public interface IUserService
{
    Task<User?> FindByIdAsync(Guid id);
    Task<User?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task<string> GenerateEmailConfirmationTokenAsync(User user);
    Task<IdentityResult> CreateUserAsync(User user, string? password = null);
    Task<IdentityResult> ConfirmUserEmailAsync(User user, string token);
}
