using System.Runtime.CompilerServices;
using ByteSpot.Shared.Infrastructure.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

[assembly: InternalsVisibleTo("ByteSpot.Bootstrapper")]
namespace ByteSpot.Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddModuleInfrastructure(this IServiceCollection services)
    {
        services.AddErrorHandlingHandler();
        return services;
    }

    public static IApplicationBuilder UseModuleInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandling();
        
        return app;
    }
}