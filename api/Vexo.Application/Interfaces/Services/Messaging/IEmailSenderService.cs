namespace Vexo.Application.Interfaces.Services.Messaging;

public interface IEmailSenderService
{
    Task SendEmailAsync(string to, string subject, string htmlBody);
}
