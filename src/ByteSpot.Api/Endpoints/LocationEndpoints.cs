using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class LocationEndpoints
{
    private const string Route = "/api/locations";
    
    public static WebApplication MapLocationEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetLocationsQuery, IEnumerable<LocationDto>> handler) =>
        {
            var locations = await handler.HandleAsync(new GetLocationsQuery());
            return Results.Ok(locations);
        });
        
        return app;
    }
}