using AutoMapper;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Auth.SignUp;

public class SignUpMapper : Profile
{
    public SignUpMapper()
    {
        CreateMap<SignUpCommand, SignUpRequestDto>();
        CreateMap<SignUpRequestDto, AppUser>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}