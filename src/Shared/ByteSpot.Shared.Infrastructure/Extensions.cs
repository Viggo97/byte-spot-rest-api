using System.Reflection;
using System.Runtime.CompilerServices;
using ByteSpot.Shared.Infrastructure.Auth;
using ByteSpot.Shared.Infrastructure.Commands;
using ByteSpot.Shared.Infrastructure.Exceptions;
using ByteSpot.Shared.Infrastructure.Queries;
using ByteSpot.Shared.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

[assembly: InternalsVisibleTo("ByteSpot.Bootstrapper")]
namespace ByteSpot.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddModuleInfrastructure(this IServiceCollection services,
        IConfiguration configuration, IList<Assembly> assemblies)
    {
        services
            .AddErrorHandlingHandler()
            .AddAuth(configuration)
            .AddHostedService<AppInitializer>()
            .AddCommands(assemblies)
            .AddQueries(assemblies);
        
        return services;
    }

    public static IApplicationBuilder UseModuleInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandling();
        
        return app;
    }
    
    public static T GetModuleOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}