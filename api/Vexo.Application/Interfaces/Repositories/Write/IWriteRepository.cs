using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Repositories.Write;

public interface IWriteRepository<T> where T : BaseEntity
{
    Task SaveChangesAsync();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}