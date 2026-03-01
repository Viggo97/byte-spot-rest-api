using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class ExperienceLevelEndpoints
{
    private const string Route = "/api/experience-levels";
    
    public static WebApplication MapExperienceLevelEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetExperienceLevelsQuery, IEnumerable<ExperienceLevelDto>> handler) =>
        {
            var experienceLevels = await handler.HandleAsync(new GetExperienceLevelsQuery());
            return Results.Ok(experienceLevels);
        });
        
        return app;
    }
}