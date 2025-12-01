using Vexo.Application.Interfaces.Messaging;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Infrastructure.Email;
using Vexo.Infrastructure.Identity;
using Vexo.Infrastructure.Security;
using Vexo.Infrastructure.Urls;

namespace Vexo.Api.DependencyInjection.Infrastructure;

internal static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddScoped<IEmailTemplateRenderer, EmailTemplateRenderer>();
        services.AddScoped<IUrlBuilderService, UrlBuilderService>();

        return services;
    }
}
