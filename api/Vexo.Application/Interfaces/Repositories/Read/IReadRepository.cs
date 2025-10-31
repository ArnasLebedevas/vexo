using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Repositories.Read;

public interface IReadRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
}