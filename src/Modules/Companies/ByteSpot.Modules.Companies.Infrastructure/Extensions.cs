using System.Runtime.CompilerServices;
using ByteSpot.Modules.Companies.Infrastructure.DAL;
using ByteSpot.Shared.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("ByteSpot.Modules.Companies.Api")]
namespace ByteSpot.Modules.Companies.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddModulePostgres<CompaniesDbContext>(configuration);
            
        return services;
    }
}