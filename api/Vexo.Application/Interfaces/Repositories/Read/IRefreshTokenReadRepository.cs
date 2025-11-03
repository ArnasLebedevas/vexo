using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Repositories.Read;

public interface IRefreshTokenReadRepository : IReadRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string hashedToken);
}
