using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Vexo.Application.Registrations;

internal static class AutoMapperRegistration
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {}, Assembly.GetExecutingAssembly());

        return services;
    }
}