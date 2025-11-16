using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Repositories.Read;

public interface ICoinReadRepository
{
    IQueryable<Coin> GetActiveCoins();
}
