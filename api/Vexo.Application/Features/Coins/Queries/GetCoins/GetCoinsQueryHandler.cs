using Vexo.Application.Common;
using Vexo.Application.Common.Models;
using Vexo.Application.Features.Coins.DTOs;
using Vexo.Application.Interfaces.CQRS;
using Vexo.Application.Interfaces.Services.Coins;

namespace Vexo.Application.Features.Coins.Queries.GetCoins;

internal class GetCoinsQueryHandler(ICoinReadService coinReadService) : IQueryHandler<GetCoinsQuery, PagedResult<CoinDto>>
{
    public Task<Result<PagedResult<CoinDto>>> Handle(GetCoinsQuery request, CancellationToken cancellationToken)
    {
        return coinReadService.GetPagedCoinsAsync(request.PageNumber, request.PageSize);
    }
}