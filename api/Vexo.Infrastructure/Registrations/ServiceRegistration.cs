using Microsoft.Extensions.DependencyInjection;
using Vexo.Application.Interfaces.Security;
using Vexo.Application.Interfaces.Services;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Infrastructure.Services;
using Vexo.Infrastructure.Services.Auth;
using Vexo.Infrastructure.Services.Security;

namespace Vexo.Infrastructure.Registrations;

internal static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<ISignInService, SignInService>();
        services.AddScoped<ISignUpService, SignUpService>();

        return services;
    }
}
