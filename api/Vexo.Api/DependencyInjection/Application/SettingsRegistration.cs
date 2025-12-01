using Vexo.Application.Common.Settings;

namespace Vexo.Api.DependencyInjection.Application;

internal static class SettingsRegistration
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("Email"));
        services.Configure<AppSettings>(configuration.GetSection("App"));
        services.Configure<AuthSettings>(configuration.GetSection("Auth"));

        return services;
    }
}
