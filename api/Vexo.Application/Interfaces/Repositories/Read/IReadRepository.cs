using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Repositories.Read;

public interface IReadRepository<T> where T : IBaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
}