using ByteSpot.Api;
using ByteSpot.Api.Cors;
using ByteSpot.Api.Endpoints;
using ByteSpot.Application;
using ByteSpot.Domain;
using ByteSpot.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddApi(builder.Configuration)
    .AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => { options.WithTitle("Byte Spot Api"); });
}

app
    .UseHttpsRedirection()
    .UseCors(CorsConfiguration.CorsPolicy);

app
    .MapOfferEndpoints()
    .MapCompanyEndpoints()
    .MapLocationEndpoints()
    .MapTechnologyEndpoints()
    .MapWorkModeEndpoints()
    .MapExperienceLevelEndpoints()
    .MapEmploymentTypeEndpoints();

app.Run();