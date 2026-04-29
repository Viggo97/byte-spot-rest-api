using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.Location;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Application.Queries.Location;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class LocationEndpoints
{
    private const string Route = "/api/locations";
    
    public static WebApplication MapLocationEndpoints(this WebApplication app)
    {
        var users = app.MapGroup(Route).WithTags("Locations");
        
        users.MapGet("", async (IQueryHandler<GetLocationsQuery, IEnumerable<LocationDto>> handler) =>
        {
            var locations = await handler.HandleAsync(new GetLocationsQuery());
            return Results.Ok(locations);
        });

        users.MapGet("{id:guid}", async (Guid id, IQueryHandler<GetLocationByIdQuery, LocationDto> handler) =>
        {
            var location = await handler.HandleAsync(new GetLocationByIdQuery(id));
            return Results.Ok(location);
        });
        
        users.MapGet("{name}", async (string name, IQueryHandler<GetLocationByNameQuery, LocationDto> handler) =>
        {
            var location = await handler.HandleAsync(new GetLocationByNameQuery(name));
            return Results.Ok(location);
        });

        users.MapPost("", async (AddLocationCommand command, ICommandHandler<AddLocationCommand> handler) =>
        {
            await handler.HandleAsync(command);
        });
        
        users.MapPut("{id:guid}", async (Guid id, [FromBody] UpdateLocationCommand command,
            ICommandHandler<UpdateLocationCommand> handler) =>
        {
            var tmp = command with { Id = id };
            await handler.HandleAsync(command);

            return Results.NoContent();
        });
        
        users.MapDelete("{id:guid}", async (Guid id, ICommandHandler<RemoveLocationCommand> handler) =>
        {
            await handler.HandleAsync(new RemoveLocationCommand(id));
            
            return Results.NoContent();
        });
        
        return app;
    }
}