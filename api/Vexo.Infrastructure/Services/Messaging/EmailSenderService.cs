using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using Vexo.Application.Common.Settings;
using Vexo.Application.Interfaces.Services.Messaging;

namespace Vexo.Infrastructure.Services.Messaging;

internal sealed class EmailSenderService(IOptions<EmailSettings> options) : IEmailSenderService
{
    private readonly EmailSettings _settings = options.Value;

    public async Task SendEmailAsync(string to, string subject, string htmlBody)
    {
        var message = new MailMessage
        {
            From = new MailAddress(_settings.From),
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true
        };

        message.To.Add(new MailAddress(to));

        using var client = new SmtpClient(_settings.Server, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password),
        };

        await client.SendMailAsync(message);
    }
}
