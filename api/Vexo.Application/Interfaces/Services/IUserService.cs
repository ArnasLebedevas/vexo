using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Services;

public interface IUserService
{
    Task<AppUser?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(AppUser user, string password);
}
