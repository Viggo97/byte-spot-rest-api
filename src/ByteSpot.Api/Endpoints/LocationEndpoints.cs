using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.Location;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries.Location;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class LocationEndpoints
{
    private const string Route = "/api/locations";
    
    public static WebApplication MapLocationEndpoints(this WebApplication app)
    {
        var locationsGroup = app.MapGroup(Route).WithTags("Locations");
        
        locationsGroup.MapGet("", async (IQueryHandler<GetLocationsQuery, IEnumerable<LocationDto>> handler) =>
        {
            var locations = await handler.HandleAsync(new GetLocationsQuery());
            return Results.Ok(locations);
        });

        locationsGroup.MapGet("{id:guid}", async (Guid id, IQueryHandler<GetLocationByIdQuery, LocationDto> handler) =>
        {
            var location = await handler.HandleAsync(new GetLocationByIdQuery(id));
            return Results.Ok(location);
        });
        
        locationsGroup.MapGet("{name}", async (string name, IQueryHandler<GetLocationByNameQuery, LocationDto> handler) =>
        {
            var location = await handler.HandleAsync(new GetLocationByNameQuery(name));
            return Results.Ok(location);
        });

        locationsGroup.MapPost("", async (AddLocationCommand command, ICommandHandler<AddLocationCommand> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.Created();
        }).RequireAuthorization(builder => builder.RequireRole(Role.Admin()));
        
        locationsGroup.MapPut("{id:guid}", async (Guid id, [FromBody] UpdateLocationCommand command,
            ICommandHandler<UpdateLocationCommand> handler) =>
        {
            var cmd = command with { Id = id };
            await handler.HandleAsync(cmd);

            return Results.NoContent();
        }).RequireAuthorization(builder => builder.RequireRole(Role.Admin()));
        
        locationsGroup.MapDelete("{id:guid}", async (Guid id, ICommandHandler<RemoveLocationCommand> handler) =>
        {
            await handler.HandleAsync(new RemoveLocationCommand(id));
            
            return Results.NoContent();
        }).RequireAuthorization(builder => builder.RequireRole(Role.Admin()));
        
        return app;
    }
}