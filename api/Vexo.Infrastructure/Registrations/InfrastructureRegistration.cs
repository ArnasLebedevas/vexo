using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vexo.Infrastructure.Registrations;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services
               .AddAuthServices(configuration)
               .AddSettings(configuration)
               .AddServices();
}
