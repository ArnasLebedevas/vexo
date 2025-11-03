using Microsoft.Extensions.DependencyInjection;
using Vexo.Application.Features.Auth.SignUp;

namespace Vexo.Application.Registrations;

internal static class AutoMapperRegistration
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<SignUpMapper>());
        return services;
    }
}