using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ByteSpot.Modules.Companies.Api;

internal static class CompaniesApi
{
    private const string Route = $"{CompaniesModule.BasePath}/companies";

    public static void ExposeCompaniesApi(this WebApplication app)
    {
        app.MapGet(Route, async () => Results.Ok("Companies work!"));
    }
}