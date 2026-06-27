using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Shared.Infrastructure.Database;

public static class Extensions
{
    public static IServiceCollection AddModulePostgres<T>(this IServiceCollection services,
        IConfiguration configuration) where T : DbContext
    {
        var options = configuration.GetModuleOptions<PostgresOptions>(PostgresOptions.PostgresOptionsKey);
        services.AddDbContext<T>(builder => builder.UseNpgsql(options.ConnectionString));
        return services;
    }
}