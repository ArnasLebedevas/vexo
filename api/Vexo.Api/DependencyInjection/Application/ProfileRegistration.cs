using System.Reflection;

namespace Vexo.Api.DependencyInjection.Application;

internal static class ProfileRegistration
{
    public static IServiceCollection AddProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        return services;
    }
}