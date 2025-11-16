using AutoMapper;
using Vexo.Application.Features.Coins.DTOs;
using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Coins.Profiles;

internal sealed class CoinProfile : Profile
{
    public CoinProfile()
    {
        CreateMap<Coin, CoinDto>();
    }
}