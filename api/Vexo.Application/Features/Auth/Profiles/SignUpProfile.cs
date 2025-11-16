using AutoMapper;
using Vexo.Application.Features.Auth.Commands.SignUp;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Auth.Profiles;

internal sealed class SignUpProfile : Profile
{
    public SignUpProfile()
    {
        CreateMap<SignUpCommand, SignUpRequestDto>();
        CreateMap<SignUpRequestDto, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}