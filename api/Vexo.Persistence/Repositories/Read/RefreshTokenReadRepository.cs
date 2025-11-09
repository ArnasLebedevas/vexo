using Microsoft.EntityFrameworkCore;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Domain.Entities;

namespace Vexo.Persistence.Repositories.Read;

public class RefreshTokenReadRepository(VexoDbContext context) : ReadRepository<RefreshToken>(context), IRefreshTokenReadRepository
{
    public Task<RefreshToken?> GetByTokenAsync(string hashedToken) => 
        context.Set<RefreshToken>().Include(token => token.User).FirstOrDefaultAsync(token => token.Token == hashedToken);
}
