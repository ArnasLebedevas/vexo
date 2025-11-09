using AutoMapper;
using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Domain.Entities;

namespace Vexo.Infrastructure.Services.Auth;

internal sealed class SignUpService(
    IUserService userService,
    ITokenService tokenService,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ISignUpService
{
    public async Task<Result<AuthResponseDto>> SignUpAsync(SignUpRequestDto model)
    {
        var existingUser = await userService.FindByEmailAsync(model.Email);
        if (existingUser is not null) return AppError.Conflict(ErrorMessages.EmailAlreadyExists);

        var user = mapper.Map<User>(model);

        var creationResult = await userService.CreateUserAsync(user, model.Password);
        if (!creationResult.Succeeded) return AppError.Validation(ErrorMessages.UserCreationFailed);

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshTokenWithPlain = tokenService.GenerateRefreshToken(user);

        unitOfWork.RefreshTokens.Add(refreshTokenWithPlain.TokenEntity);
        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(accessToken, refreshTokenWithPlain.PlainToken);
    }
}
