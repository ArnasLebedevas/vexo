using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Repositories.Write;
using Vexo.Domain.Entities;
using Vexo.Persistence.Repositories.Write;

namespace Vexo.Persistence.Repositories;

public class UnitOfWork(VexoDbContext context) : IUnitOfWork
{
    public IWriteRepository<RefreshToken> RefreshTokens { get; } = new WriteRepository<RefreshToken>(context);
    public IWriteRepository<LoginCode> LoginCodes { get; } = new WriteRepository<LoginCode>(context);

    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}