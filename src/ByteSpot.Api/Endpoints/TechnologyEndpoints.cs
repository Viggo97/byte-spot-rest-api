using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class TechnologyEndpoints
{
    private const string Route = "/api/technologies";
    
    public static WebApplication MapTechnologyEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>> handler) =>
        {
            var technologies = await handler.HandleAsync(new GetTechnologiesQuery());
            return Results.Ok(technologies);
        });
        
        return app;
    }
}