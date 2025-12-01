using Microsoft.AspNetCore.Identity;
using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetByEmailAsync(string email);

    Task<bool> CheckPasswordAsync(User user, string password);

    Task<IdentityResult> CreateUserAsync(User user);

    Task<string> GenerateEmailConfirmationTokenAsync(User user);
}