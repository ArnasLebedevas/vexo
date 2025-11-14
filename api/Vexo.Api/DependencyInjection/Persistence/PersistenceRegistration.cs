namespace Vexo.Api.DependencyInjection.Persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) =>
        services
               .AddDatabase(configuration)
               .AddRepositories();
}