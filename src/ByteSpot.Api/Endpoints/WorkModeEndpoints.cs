using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class WorkModeEndpoints
{
    private const string Route = "/api/work-modes";
    
    public static WebApplication MapWorkModeEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetWorkModesQuery, IEnumerable<WorkModeDto>> handler) =>
        {
            var workModes = await handler.HandleAsync(new GetWorkModesQuery());
            return Results.Ok(workModes);
        });
        
        return app;
    }
}