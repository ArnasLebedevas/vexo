using Vexo.Application.Common.Settings;

namespace Vexo.Api.DependencyInjection.Application;

internal static class SettingsRegistration
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        services.Configure<EmailSettings>(configuration.GetSection("Email"));
        services.Configure<AppSettings>(configuration.GetSection("App"));

        return services;
    }
}
