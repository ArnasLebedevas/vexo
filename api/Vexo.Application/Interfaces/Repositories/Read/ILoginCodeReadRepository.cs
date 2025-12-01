using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Repositories.Read;

public interface ILoginCodeReadRepository
{
    Task<LoginCode?> GetValidCodeAsync(Guid userId, string code);
}
