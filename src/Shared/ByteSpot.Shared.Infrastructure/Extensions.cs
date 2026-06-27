using System.Runtime.CompilerServices;
using ByteSpot.Shared.Infrastructure.Exceptions;
using ByteSpot.Shared.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

[assembly: InternalsVisibleTo("ByteSpot.Bootstrapper")]
namespace ByteSpot.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddModuleInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddErrorHandlingHandler()
            .AddHostedService<AppInitializer>();
        
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