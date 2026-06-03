using ByteSpot.Api.Utils;
using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Commands.ExperienceLevel;
using ByteSpot.Application.Queries.ExperienceLevel;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class ExperienceLevelEndpoints
{
    private const string Route = "/api/experience-levels";

    public static WebApplication MapExperienceLevelEndpoints(this WebApplication app)
    {
        var experienceLevelsGroup = app.MapGroup(Route).WithTags("Experience Levels");

        experienceLevelsGroup
            .MapGet("", async (IQueryHandler<GetExperienceLevelsQuery, IEnumerable<ExperienceLevelDto>> handler,
                HttpContext httpContext) =>
            {
                var languageCode = LanguageCodeConverter.Get(httpContext);
                var query = new GetExperienceLevelsQuery(languageCode);
                var experienceLevels = await handler.HandleAsync(query);
                return Results.Ok(experienceLevels);
            });

        experienceLevelsGroup
            .MapGet("{id:int}",
                async (int id, IQueryHandler<GetExperienceLevelQuery, ExperienceLevelWithTranslationsDto> handler) =>
                {
                    var query = new GetExperienceLevelQuery(id);
                    var experienceLevel = await handler.HandleAsync(query);
                    return Results.Ok(experienceLevel);
                });

        experienceLevelsGroup
            .MapPost("",
                async (AddExperienceLevelCommand command, ICommandHandler<AddExperienceLevelCommand> handler) =>
                {
                    await handler.HandleAsync(command);
                    return Results.Created();
                })
            .RequireAuthorization(builder => builder.RequireRole(Role.Admin()));

        experienceLevelsGroup
            .MapPut("{id:int}", async (int id, [FromBody] UpdateExperienceLevelCommand command,
                ICommandHandler<UpdateExperienceLevelCommand> handler) =>
            {
                var cmd = command with { Id = id };
                await handler.HandleAsync(cmd);
                return Results.NoContent();
            })
            .RequireAuthorization(builder => builder.RequireRole(Role.Admin()));

        experienceLevelsGroup
            .MapDelete("{id:int}", async (int id, ICommandHandler<RemoveExperienceLevelCommand> handler) =>
            {
                await handler.HandleAsync(new RemoveExperienceLevelCommand(id));
                return Results.NoContent();
            })
            .RequireAuthorization(builder => builder.RequireRole(Role.Admin()));

        return app;
    }
}