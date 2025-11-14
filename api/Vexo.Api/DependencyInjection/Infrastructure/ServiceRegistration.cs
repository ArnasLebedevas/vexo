using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Application.Interfaces.Services.Messaging;
using Vexo.Infrastructure.Email;
using Vexo.Infrastructure.Identity;
using Vexo.Infrastructure.Security;

namespace Vexo.Api.DependencyInjection.Infrastructure;

internal static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUrlTokenEncoder, UrlTokenEncoder>();
        services.AddScoped<IEmailSenderService, EmailSenderService>();

        return services;
    }
}
