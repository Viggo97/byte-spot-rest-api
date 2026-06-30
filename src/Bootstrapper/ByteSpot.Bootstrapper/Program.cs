using ByteSpot.Bootstrapper;
using ByteSpot.Bootstrapper.Cors;
using ByteSpot.Bootstrapper.Endpoints;
using ByteSpot.Application;
using ByteSpot.Domain;
using ByteSpot.Infrastructure;
using ByteSpot.Shared.Infrastructure;
using ByteSpot.Shared.Infrastructure.Modules;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddApi(builder.Configuration)
    .AddOpenApi();

builder.Host.ConfigureModules();
var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assemblies);
builder.Services.AddModuleInfrastructure(builder.Configuration, assemblies);
RegisterModules();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => { options.WithTitle("Byte Spot Api"); });
}

app
    .UseHttpsRedirection()
    .UseCors(CorsConfiguration.CorsPolicy);

app.UseInfrastructure();

app
    .MapUserEndpoints()
    .MapOfferEndpoints()
    .MapCompanyEndpoints()
    .MapLocationEndpoints()
    .MapTechnologyEndpoints()
    .MapWorkModeEndpoints()
    .MapExperienceLevelEndpoints()
    .MapEmploymentTypeEndpoints()
    .MapApplicationEndpoints();

app.UseModuleInfrastructure();
UseModules();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation($"Modules: {string.Join(", ",  modules.Select(m => m.Name))}");

assemblies.Clear();
modules.Clear();

app.Run();

return;

void RegisterModules()
{
    foreach (var module in modules)
    {
        module.Register(builder.Services, builder.Configuration);
    }
}

void UseModules()
{
    foreach (var module in modules)
    {
        module.Use(app);
        module.Expose(app);
    }
}