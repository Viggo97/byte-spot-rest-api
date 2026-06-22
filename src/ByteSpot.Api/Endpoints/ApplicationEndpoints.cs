using ByteSpot.Api.Files;
using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.Application;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class ApplicationEndpoints
{
    private const string Route = "/api/applications";

    public static WebApplication MapApplicationEndpoints(this WebApplication app)
    {
        var applicationsGroup = app.MapGroup(Route).WithTags("Applications");
        
        applicationsGroup
            .MapPost("", async ([FromForm] AddApplicationDocument data ,ICommandHandler<AddApplicationCommand> handler) =>
            {
                if (data.Resume.Length == 0)
                    return Results.BadRequest("File is empty.");

                if (data.Resume.ContentType != "application/pdf")
                    return Results.BadRequest("Only pdf files are supported.");
                
                var memoryStream = new MemoryStream();
                await data.Resume.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var command = new AddApplicationCommand(
                    data.OfferId,
                    data.CandidateFirstName,
                    data.CandidateLastName,
                    data.CandidateEmail,
                    memoryStream
                );
                
                await handler.HandleAsync(command);
                return Results.Created();
            })
            .DisableAntiforgery();
        
        return app;
    }
}