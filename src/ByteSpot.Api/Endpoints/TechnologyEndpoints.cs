using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.Technology;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries.Technology;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class TechnologyEndpoints
{
    private const string Route = "/api/technologies";
    
    public static WebApplication MapTechnologyEndpoints(this WebApplication app)
    {
        var technologiesGroup = app.MapGroup(Route).WithTags("Technologies");
        
        technologiesGroup.MapGet("", async (IQueryHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>> handler) =>
        {
            var technologies = await handler.HandleAsync(new GetTechnologiesQuery());
            return Results.Ok(technologies);
        });

        technologiesGroup.MapGet("{id:guid}", async (Guid id, IQueryHandler<GetTechnologyByIdQuery, TechnologyDto> handler) =>
        {
            var technology = await handler.HandleAsync(new GetTechnologyByIdQuery(id));
            return Results.Ok(technology);
        });

        technologiesGroup.MapPost("", async (AddTechnologyCommand command, ICommandHandler<AddTechnologyCommand> handler) =>
        {
            await handler.HandleAsync(command);
        });
        
        technologiesGroup.MapPut("{id:guid}", async (Guid id, [FromBody] UpdateTechnologyCommand command,
            ICommandHandler<UpdateTechnologyCommand> handler) =>
        {
            var tmp = command with { Id = id };
            await handler.HandleAsync(command);

            return Results.NoContent();
        });
        
        technologiesGroup.MapDelete("{id:guid}", async (Guid id, ICommandHandler<RemoveTechnologyCommand> handler) =>
        {
            await handler.HandleAsync(new RemoveTechnologyCommand(id));
            
            return Results.NoContent();
        });
        
        return app;
    }
}