using ByteSpot.Modules.Users.Application.Auth;
using ByteSpot.Modules.Users.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Modules.Users.Infrastructure.Auth;

internal static class Extensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>()
            .AddScoped<ISignInStorage, HttpContextSignInStorage>();

        return services;
    }
}