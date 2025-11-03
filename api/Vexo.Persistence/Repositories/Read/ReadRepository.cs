using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Domain.Entities;

namespace Vexo.Persistence.Repositories.Read;

public class ReadRepository<T>(VexoDbContext context) : IReadRepository<T> 
    where T : class, IBaseEntity
{
    protected readonly VexoDbContext context = context;

    public async Task<T?> GetByIdAsync(Guid id) => await context.Set<T>().FindAsync(id);
}
