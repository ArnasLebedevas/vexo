using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Domain.Entities;
using Vexo.Domain.Enums;

namespace Vexo.Persistence.Repositories.Read;

public class CoinReadRepository(VexoDbContext context) : ReadRepository<RefreshToken>(context), ICoinReadRepository
{
    public IQueryable<Coin> GetActiveCoins() => context.Set<Coin>().Where(c => c.Status == CoinStatus.Active);
}
