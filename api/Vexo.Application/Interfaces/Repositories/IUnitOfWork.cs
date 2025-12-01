using Vexo.Application.Interfaces.Repositories.Write;
using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    IWriteRepository<RefreshToken> RefreshTokens { get; }
    IWriteRepository<LoginCode> LoginCodes { get; }

    Task SaveChangesAsync();
}
