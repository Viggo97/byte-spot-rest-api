using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands;
using ByteSpot.Application.Security;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Api.Endpoints;

public static class UserEndpoints
{
    private const string Route = "/api/users";
    
    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
        app.MapPost($"{Route}/sign-up", async (SignUpCommand command, ICommandHandler<SignUpCommand> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.Created();
        });
        
        app.MapPost($"{Route}/sign-in", async (SignInCommand command, ICommandHandler<SignInCommand> handler,
            ISignInStorage signInStorage) =>
        {
            await handler.HandleAsync(command);
            var userDto = signInStorage.Get();
            return Results.Ok(userDto);
        });
        
        app.MapPost($"{Route}/refresh-token", async (HttpContext httpContext, ICommandHandler<RefreshTokenCommand> handler) =>
        {
            var refreshToken = httpContext.Request.Cookies[AuthCookieKey.RefreshToken.Value];
            var command = new RefreshTokenCommand(refreshToken);
            await handler.HandleAsync(command);
            
            return Results.Ok();
        });
        
        app.MapPost($"{Route}/logout", async (HttpContext httpContext, ICommandHandler<LogoutCommand> handler) =>
        {
            var refreshToken = httpContext.Request.Cookies[AuthCookieKey.RefreshToken.Value];
            var command = new LogoutCommand(refreshToken);
            await handler.HandleAsync(command);
            
            return Results.Ok();
        });
        
        return app;
    }
    
}