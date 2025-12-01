namespace Vexo.Application.Interfaces.Messaging;

public interface IEmailSenderService
{
    Task SendEmailAsync(string to, string subject, string htmlBody);
}
