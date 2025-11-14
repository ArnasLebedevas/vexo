namespace Vexo.Api.DependencyInjection.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) => 
        services
               .AddJwtServices(configuration)
               .AddIdentity()
               .AddInfrastructureServices();
}
