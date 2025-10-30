using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vexo.Application.Common.Settings;

namespace Vexo.Infrastructure.Registrations;

internal static class SettingRegistration
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        return services;
    }
}
