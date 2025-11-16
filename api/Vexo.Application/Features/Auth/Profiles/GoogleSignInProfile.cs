using AutoMapper;
using Google.Apis.Auth;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Auth.Profiles;

internal sealed class GoogleSignInProfile : Profile
{
    public GoogleSignInProfile()
    {
        CreateMap<GoogleJsonWebSignature.Payload, GoogleUserDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.GivenName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FamilyName));

        CreateMap<GoogleUserDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(_ => true))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}