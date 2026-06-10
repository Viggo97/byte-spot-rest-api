using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands;
using ByteSpot.Application.Queries.User;
using ByteSpot.Application.Security;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class UserEndpoints
{
    private const string Route = "/api/users";

    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
        var usersGroup = app.MapGroup(Route).WithTags("Users");

        usersGroup
            .MapPost("/sign-up", async (SignUpCommand command, ICommandHandler<SignUpCommand> handler) =>
            {
                await handler.HandleAsync(command);
                return Results.Created();
            });

        usersGroup
            .MapPost("/sign-in", async (SignInCommand command, ICommandHandler<SignInCommand> handler,
                ISignInStorage signInStorage) =>
            {
                await handler.HandleAsync(command);
                var userDto = signInStorage.Get();
                return Results.Ok(userDto);
            });

        usersGroup
            .MapPost("/refresh-token", async (HttpContext httpContext, ICommandHandler<RefreshTokenCommand> handler,
                ISignInStorage signInStorage) =>
            {
                var refreshToken = httpContext.Request.Cookies[AuthCookieKey.RefreshToken.Value];
                var command = new RefreshTokenCommand(refreshToken);
                await handler.HandleAsync(command);
                var userDto = signInStorage.Get();

                return Results.Ok(userDto);
            });

        usersGroup
            .MapPost("/logout", async (HttpContext httpContext, ICommandHandler<LogoutCommand> handler) =>
            {
                var refreshToken = httpContext.Request.Cookies[AuthCookieKey.RefreshToken.Value];
                var command = new LogoutCommand(refreshToken);
                await handler.HandleAsync(command);

                return Results.Ok();
            });

        usersGroup
            .MapGet("/validate-email", async ([FromQuery(Name = "email")] string? email, IQueryHandler<GetEmailAvailabilityQuery, bool> handler) =>
            {
                if (email is null)
                {
                    return Results.BadRequest();
                }
                var isValid = await handler.HandleAsync(new  GetEmailAvailabilityQuery(email));
                return Results.Ok(isValid);
            });

        return app;
    }
}