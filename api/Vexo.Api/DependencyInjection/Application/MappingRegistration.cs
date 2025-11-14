using System.Reflection;

namespace Vexo.Api.DependencyInjection.Application;

internal static class MappingRegistration
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

        return services;
    }
}