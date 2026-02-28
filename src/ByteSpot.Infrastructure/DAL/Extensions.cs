using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Infrastructure.DAL;

internal static class Extensions
{
    private const string PostgresSectionName = "postgres";
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(PostgresSectionName));
        var postgresOptions = configuration.GetOptions<PostgresOptions>(PostgresSectionName);

        services
            .AddDbContext<ByteSpotDbContext>(options => options.UseNpgsql(postgresOptions.ConnectionString))
            .AddHostedService<DatabaseInitializer>()
            .AddScoped<DatabaseSeeder>();
        
        return services;
    }
}