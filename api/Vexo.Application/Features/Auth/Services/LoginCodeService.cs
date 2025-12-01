using MediatR;
using Microsoft.Extensions.Options;
using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Common.Settings;
using Vexo.Application.Common.Utils;
using Vexo.Application.Features.Auth.DTOs;
using Vexo.Application.Interfaces.Repositories;
using Vexo.Application.Interfaces.Repositories.Read;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Auth.Services;

public class LoginCodeService(
    IUserService userService,
    IEmailService emailService,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    ILoginCodeReadRepository loginCodeReadRepository,
    IOptions<AuthSettings> options) : ILoginCodeService
{
    private readonly LoginCodeSettings _loginCodeSettings = options.Value.LoginCode;

    public async Task<Result<Unit>> RequestLoginCodeAsync(string email)
    {
        var user = await userService.GetByEmailAsync(email);
        if (user is null)
        {
            user = User.Create(email);
            await userService.CreateUserAsync(user);
        }

        if (user.EmailConfirmed) return Unit.Value;

        var code = CodeGenerator.Generate6DigitCode();

        var loginCode = LoginCode.Create(user.Id, code, _loginCodeSettings.ExpirationMinutes);

        unitOfWork.LoginCodes.Add(loginCode);
        await unitOfWork.SaveChangesAsync();

        await emailService.SendLoginCodeEmail(user, code);

        return Unit.Value;
    }

    public async Task<Result<AuthResponseDto>> VerifyLoginCodeAsync(string email, string inputCode)
    {
        var user = await userService.GetByEmailAsync(email);
        if (user is null || user.EmailConfirmed) return AppError.Unauthorized(ErrorMessages.InvalidCredentials);

        var code = await loginCodeReadRepository.GetValidCodeAsync(user.Id, inputCode);
        if (code is null) return AppError.Unauthorized(ErrorMessages.InvalidOrExpiredLoginCode);

        user.MarkEmailConfirmed();
        code.MarkAsUsed();
        user.RevokeAllActiveTokens();

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshTokenWithPlain = tokenService.GenerateRefreshToken(user);

        unitOfWork.RefreshTokens.Add(refreshTokenWithPlain.TokenEntity);
        await unitOfWork.SaveChangesAsync();

        return new AuthResponseDto(accessToken, refreshTokenWithPlain.PlainToken);
    }
}
