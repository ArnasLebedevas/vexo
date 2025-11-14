using Microsoft.EntityFrameworkCore;
using Vexo.Persistence;

namespace Vexo.Api.DependencyInjection.Persistence;

internal static class DbContextRegistration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<VexoDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}