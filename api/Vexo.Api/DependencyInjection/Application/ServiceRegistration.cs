using Vexo.Application.Features.Auth.Services;
using Vexo.Application.Features.Coins.Services;
using Vexo.Application.Interfaces.Services.Auth;
using Vexo.Application.Interfaces.Services.Coins;

namespace Vexo.Api.DependencyInjection.Application;

internal static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<ISignInService, SignInService>();
        services.AddScoped<ISignUpService, SignUpService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ICoinReadService, CoinReadService>();

        return services;
    }
}
