using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Text;
using Vexo.Application.Common;
using Vexo.Application.Common.Errors;
using Vexo.Application.Common.Messages;
using Vexo.Application.Common.Settings;
using Vexo.Application.Interfaces.Services;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Application.Interfaces.Services.Messaging;
using Vexo.Domain.Entities;

namespace Vexo.Infrastructure.Services.Auth;

internal sealed class EmailService(
    IUserService userService,
    IEmailSenderService emailSenderService,
    IOptions<AppSettings> appSettings) : IEmailService
{
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task SendConfirmationEmailAsync(User user)
    {
        if (user.Email is null || user.EmailConfirmed) return;

        var token = await userService.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
        var confirmLink = $"{_appSettings.BaseUrl}/api/auth/confirm-email?userId={user.Id}&token={encodedToken}";

        var subject = "Confirm your email";
        var body = $"<p>Click <a href=\"{confirmLink}\">here</a> to confirm your email.</p>";

        await emailSenderService.SendEmailAsync(user.Email, subject, body);
    }

    public async Task<Result<Unit>> ConfirmEmailAsync(Guid userId, string token)
    {
        var user = await userService.FindByIdAsync(userId);
        if (user is null) return AppError.NotFound(ErrorMessages.UserNotFound);

        var decoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
        var result = await userService.ConfirmUserEmailAsync(user, decoded);

        return result.Succeeded ? Unit.Value : AppError.Validation(ErrorMessages.InvalidEmailConfirmationToken);
    }

    public async Task<Result<Unit>> ResendConfirmationEmailAsync(Guid userId)
    {
        var user = await userService.FindByIdAsync(userId);

        if (user is null) return AppError.NotFound(ErrorMessages.UserNotFound);
        if (user.EmailConfirmed) return AppError.Conflict(ErrorMessages.EmailAlreadyConfirmed);

        await SendConfirmationEmailAsync(user);

        return Unit.Value;
    }
}
