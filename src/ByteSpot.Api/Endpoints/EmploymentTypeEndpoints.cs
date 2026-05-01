using ByteSpot.Api.Utils;
using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using ByteSpot.Application.Commands.EmploymentType;
using ByteSpot.Application.Queries.EmploymentType;

namespace ByteSpot.Api.Endpoints;

public static class EmploymentTypeEndpoints
{
    private const string Route = "/api/employment-types";
    
    public static WebApplication MapEmploymentTypeEndpoints(this WebApplication app)
    {
        var employmentTypesGroup = app.MapGroup(Route).WithTags("Employment Types");
        
        employmentTypesGroup.MapGet("", async (IQueryHandler<GetEmploymentTypesQuery, IEnumerable<EmploymentTypeDto>> handler,
            HttpContext httpContext) =>
        {
            var languageCode = LanguageCodeConverter.Get(httpContext);
            var query = new GetEmploymentTypesQuery(languageCode);
            var employmentTypes = await handler.HandleAsync(query);
            return Results.Ok(employmentTypes);
        });

        employmentTypesGroup.MapGet("{id:int}", async (int id, IQueryHandler<GetEmploymentTypeQuery, EmploymentTypeWithTranslationsDto> handler) =>
        {
            var query = new GetEmploymentTypeQuery(id);
            var employmentType = await handler.HandleAsync(query);
            return Results.Ok(employmentType);
        });
        
        employmentTypesGroup.MapPost("", async (AddEmploymentTypeCommand command, ICommandHandler<AddEmploymentTypeCommand> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.Created();
        });
        
        employmentTypesGroup.MapPut("{id:int}", async (int id, [FromBody] UpdateEmploymentTypeCommand command,
            ICommandHandler<UpdateEmploymentTypeCommand> handler) =>
        {
            var cmd = command with { Id = id };
            await handler.HandleAsync(cmd);
            return Results.NoContent();
        });
        
        employmentTypesGroup.MapDelete("{id:int}", async (int id, ICommandHandler<RemoveEmploymentTypeCommand> handler) =>
        {
            await handler.HandleAsync(new RemoveEmploymentTypeCommand(id));
            return Results.NoContent();
        });
        
        return app;
    }
}