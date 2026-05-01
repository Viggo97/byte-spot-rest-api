using ByteSpot.Api.Utils;
using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.WorkMode;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries.WorkMode;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class WorkModeEndpoints
{
    private const string Route = "/api/work-modes";
    
    public static WebApplication MapWorkModeEndpoints(this WebApplication app)
    {
        var workModesGroup = app.MapGroup(Route).WithTags("Work Modes");
        
        workModesGroup.MapGet("", async (IQueryHandler<GetWorkModesQuery, IEnumerable<WorkModeDto>> handler, HttpContext httpContext) =>
        {
            var languageCode = LanguageCodeConverter.Get(httpContext);
            var query = new GetWorkModesQuery(languageCode);
            var workModes = await handler.HandleAsync(query);
            return Results.Ok(workModes);
        });

        workModesGroup.MapGet("{id:int}", async (int id, IQueryHandler<GetWorkModeQuery, WorkModeWithTranslationsDto> handler) =>
        {
            var query = new GetWorkModeQuery(id);
            var workMode = await handler.HandleAsync(query);
            return Results.Ok(workMode);
        });
        
        workModesGroup.MapPost("", async (AddWorkModeCommand command, ICommandHandler<AddWorkModeCommand> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.Created();
        });
        
        workModesGroup.MapPut("{id:int}", async (int id, [FromBody] UpdateWorkModeCommand command,
            ICommandHandler<UpdateWorkModeCommand> handler) =>
        {
            var cmd = command with { Id = id };
            await handler.HandleAsync(cmd);
            return Results.NoContent();
        });
        
        workModesGroup.MapDelete("{id:int}", async (int id, ICommandHandler<RemoveWorkModeCommand> handler) =>
        {
            await handler.HandleAsync(new RemoveWorkModeCommand(id));
            return Results.NoContent();
        });
        
        return app;
    }
}