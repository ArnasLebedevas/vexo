using Microsoft.Extensions.DependencyInjection;

namespace Vexo.Application.Registrations;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
               .AddMediatRServices()
               .AddMapper();
}