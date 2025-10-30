using Vexo.Infrastructure.Registrations;
using Vexo.Persistence.Registrations;

namespace Vexo.Api.Registrations;

internal static class Registrations
{
    public static IServiceCollection AddRegistrations(this IServiceCollection services, IConfiguration configuration) =>
        services
               .AddIdentity()
               .AddPersistence(configuration)
               .AddInfrastructure(configuration);
}
