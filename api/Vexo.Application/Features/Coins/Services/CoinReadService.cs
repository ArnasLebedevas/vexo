using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Vexo.Application.Common;
using Vexo.Application.Common.Models;
using Vexo.Application.Features.Coins.DTOs;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Application.Interfaces.Services.Coins;

namespace Vexo.Application.Features.Coins.Services;

public class CoinReadService(ICoinReadRepository coinReadRepository, IMapper mapper) : ICoinReadService
{
    public async Task<Result<PagedResult<CoinDto>>> GetPagedCoinsAsync(int page, int size)
    {
        var query = coinReadRepository.GetActiveCoins();

        var total = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * size)
            .Take(size)
            .ProjectTo<CoinDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResult<CoinDto>(items, total, page, size);
    }
}
