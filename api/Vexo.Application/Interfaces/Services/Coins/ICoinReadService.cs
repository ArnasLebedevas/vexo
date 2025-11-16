using Vexo.Application.Common;
using Vexo.Application.Common.Models;
using Vexo.Application.Features.Coins.DTOs;

namespace Vexo.Application.Interfaces.Services.Coins;

public interface ICoinReadService
{
    Task<Result<PagedResult<CoinDto>>> GetPagedCoinsAsync(int page, int size);
}
