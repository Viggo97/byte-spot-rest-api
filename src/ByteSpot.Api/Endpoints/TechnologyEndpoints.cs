using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.Technology;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries.Technology;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class TechnologyEndpoints
{
    private const string Route = "/api/technologies";

    public static WebApplication MapTechnologyEndpoints(this WebApplication app)
    {
        var technologiesGroup = app.MapGroup(Route).WithTags("Technologies");

        technologiesGroup
            .MapGet("", async (IQueryHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>> handler) =>
            {
                var technologies = await handler.HandleAsync(new GetTechnologiesQuery());
                return Results.Ok(technologies);
            });

        technologiesGroup
            .MapGet("{id:guid}",
                async (Guid id, IQueryHandler<GetTechnologyByIdQuery, TechnologyDto> handler) =>
                {
                    var technology = await handler.HandleAsync(new GetTechnologyByIdQuery(id));
                    return Results.Ok(technology);
                });

        technologiesGroup
            .MapPost("", async (AddTechnologyCommand command,
                ICommandHandler<AddTechnologyCommand> handler) =>
            {
                await handler.HandleAsync(command);
                return Results.Created();
            })
            .RequireAuthorization(builder => builder.RequireRole(Role.Admin()));

        technologiesGroup
            .MapPut("{id:guid}", async (Guid id, [FromBody] UpdateTechnologyCommand command,
                ICommandHandler<UpdateTechnologyCommand> handler) =>
            {
                var cmd = command with { Id = id };
                await handler.HandleAsync(cmd);

                return Results.NoContent();
            })
            .RequireAuthorization(builder => builder.RequireRole(Role.Admin()));

        technologiesGroup
            .MapDelete("{id:guid}", async (Guid id, ICommandHandler<RemoveTechnologyCommand> handler) =>
            {
                await handler.HandleAsync(new RemoveTechnologyCommand(id));

                return Results.NoContent();
            })
            .RequireAuthorization(builder => builder.RequireRole(Role.Admin()));

        return app;
    }
}