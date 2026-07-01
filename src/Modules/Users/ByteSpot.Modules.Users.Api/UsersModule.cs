using ByteSpot.Modules.Users.Application;
using ByteSpot.Modules.Users.Domain;
using ByteSpot.Modules.Users.Infrastructure;
using ByteSpot.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Modules.Users.Api;

internal class UsersModule : IModule
{
    public const string BasePath = "/api/users-module";
    public string Name { get; } = "Users";
    public string Path => BasePath;
    
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDomain()
            .AddApplication()
            .AddInfrastructure(configuration);
    }

    public void Use(IApplicationBuilder builder)
    {
    }

    public void Expose(WebApplication app)
    {
        app.ExposeUsersApi();
    }
}