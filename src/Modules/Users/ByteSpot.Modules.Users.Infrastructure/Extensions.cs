using System.Runtime.CompilerServices;
using ByteSpot.Modules.Users.Domain.Repositories;
using ByteSpot.Modules.Users.Infrastructure.Auth;
using ByteSpot.Modules.Users.Infrastructure.DAL;
using ByteSpot.Modules.Users.Infrastructure.DAL.Repositories;
using ByteSpot.Shared.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("ByteSpot.Modules.Users.Api")]
namespace ByteSpot.Modules.Users.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddAuth()
            .AddModulePostgres<UsersDbContext>(configuration)
            .AddScoped<IUserRepository, PostgresUserRepository>();
    }
}