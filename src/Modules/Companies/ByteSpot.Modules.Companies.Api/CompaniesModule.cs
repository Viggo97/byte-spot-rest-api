using ByteSpot.Modules.Companies.Application;
using ByteSpot.Modules.Companies.Domain;
using ByteSpot.Modules.Companies.Infrastructure;
using ByteSpot.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Modules.Companies.Api;

internal class CompaniesModule : IModule
{
    public const string BasePath = "/api/companies-module";
    public string Name { get; } = "Companies";
    public string Path => BasePath;
    
    public void Register(IServiceCollection services)
    {
        services
            .AddDomain()
            .AddApplication()
            .AddInfrastructure();
    }

    public void Use(IApplicationBuilder builder)
    {
    }

    public void Expose(WebApplication app)
    {
        app.ExposeCompaniesApi();
    }
}