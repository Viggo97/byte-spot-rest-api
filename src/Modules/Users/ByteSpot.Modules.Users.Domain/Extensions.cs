using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("ByteSpot.Modules.Users.Api")]
namespace ByteSpot.Modules.Users.Domain;

internal static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}