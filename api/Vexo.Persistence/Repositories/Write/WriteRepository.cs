using Vexo.Application.Interfaces.Repositories.Write;
using Vexo.Domain.Entities;

namespace Vexo.Persistence.Repositories.Write;

public class WriteRepository<T>(VexoDbContext context) : IWriteRepository<T> where T : BaseEntity
{
    protected readonly VexoDbContext context = context;

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
    public void Add(T model) => context.Set<T>().Add(model);
    public void Update(T model) => context.Set<T>().Update(model);
    public void Delete(T model) => context.Set<T>().Remove(model);
}