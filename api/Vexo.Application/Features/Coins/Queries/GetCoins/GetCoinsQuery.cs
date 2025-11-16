using Vexo.Application.Common.Models;
using Vexo.Application.Features.Coins.DTOs;
using Vexo.Application.Interfaces.CQRS;

namespace Vexo.Application.Features.Coins.Queries.GetCoins;

public record GetCoinsQuery(int PageNumber = 1, int PageSize = 100) : IQuery<PagedResult<CoinDto>>;