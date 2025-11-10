using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vexo.Application.Common.Settings;

namespace Vexo.Infrastructure.Registrations;

internal static class SettingRegistration
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        services.Configure<EmailSettings>(configuration.GetSection("Email"));
        services.Configure<AppSettings>(configuration.GetSection("App"));

        return services;
    }
}
