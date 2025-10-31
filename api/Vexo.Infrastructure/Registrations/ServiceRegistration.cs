using Microsoft.Extensions.DependencyInjection;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Infrastructure.Services;
using Vexo.Infrastructure.Services.Identity;
using Vexo.Infrastructure.Services.Security;

namespace Vexo.Infrastructure.Registrations;

internal static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, IdentityUserService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
