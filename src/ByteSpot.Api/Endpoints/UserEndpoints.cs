using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands;

namespace ByteSpot.Api.Endpoints;

public static class UserEndpoints
{
    private const string Route = "/api/users";
    
    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
        app.MapPost($"{Route}", async (SignUpCommand command, ICommandHandler<SignUpCommand> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.Created();
        });
        
        return app;
    }
    
}