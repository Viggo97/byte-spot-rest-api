using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ByteSpot.Modules.Users.Api;

internal static class UsersApi
{
    private const string Route = $"{UsersModule.BasePath}/users";
    
    public static void ExposeUsersApi(this WebApplication app)
    {
        app.MapGet(Route, async () => Results.Ok("Users work!"));
    }
}