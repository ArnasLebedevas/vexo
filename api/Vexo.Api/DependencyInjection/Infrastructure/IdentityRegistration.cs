using Microsoft.AspNetCore.Identity;
using Vexo.Domain.Entities;
using Vexo.Persistence;

namespace Vexo.Api.DependencyInjection.Infrastructure;

internal static class IdentityRegistration
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 1;
            options.User.RequireUniqueEmail = true;
            options.Lockout.AllowedForNewUsers = false;
        })
          .AddEntityFrameworkStores<VexoDbContext>()
          .AddDefaultTokenProviders();


        return services;
    }
}
