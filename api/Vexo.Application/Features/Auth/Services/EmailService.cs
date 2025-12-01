using Vexo.Application.Common.Email;
using Vexo.Application.Common.Models;
using Vexo.Application.Interfaces.Messaging;
using Vexo.Application.Interfaces.Services;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Domain.Entities;

namespace Vexo.Application.Features.Auth.Services;

public sealed class EmailService(
    IEmailSenderService emailSender,
    IEmailTemplateRenderer template,
    IUrlBuilderService urlBuilder) : IEmailService
{
    public async Task SendLoginCodeEmail(User user, string code)
    {
        if (user.Email is null) return;

        var loginUrl = urlBuilder.BuildPasswordlessLoginUrl(user.Email, code);

        var model = new LoginCodeEmailModel(user.Email, code, loginUrl);

        var html = await template.RenderAsync(EmailTemplates.LoginCode, model);

        await emailSender.SendEmailAsync(user.Email, EmailSubjects.LoginCode, html);
    }
}
