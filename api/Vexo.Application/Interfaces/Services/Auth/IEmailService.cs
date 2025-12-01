using Vexo.Domain.Entities;

namespace Vexo.Application.Interfaces.Services.Auth;

public interface IEmailService
{
    Task SendLoginCodeEmail(User user, string code);
}
