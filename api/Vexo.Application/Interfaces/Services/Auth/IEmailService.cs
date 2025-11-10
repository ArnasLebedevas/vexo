using MediatR;
using Vexo.Application.Common;
using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Services.Auth;

public interface IEmailService
{
    Task SendConfirmationEmailAsync(User user);
    Task<Result<Unit>> ConfirmEmailAsync(Guid userId, string token);
    Task<Result<Unit>> ResendConfirmationEmailAsync(Guid userId);
}
