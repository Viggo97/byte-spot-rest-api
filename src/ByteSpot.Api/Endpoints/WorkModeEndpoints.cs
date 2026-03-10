using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Domain.Enums;

namespace ByteSpot.Api.Endpoints;

public static class WorkModeEndpoints
{
    private const string Route = "/api/work-modes";
    
    public static WebApplication MapWorkModeEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetWorkModesQuery, IEnumerable<WorkModeDto>> handler, HttpContext httpContext) =>
        {
            var acceptLanguageHeader = httpContext.Request.Headers.AcceptLanguage;
            var languageParsed = Enum.TryParse(acceptLanguageHeader, out LanguageCode languageCode);
            var query = new GetWorkModesQuery(languageParsed ? languageCode : LanguageCode.En);
            var workModes = await handler.HandleAsync(query);
            return Results.Ok(workModes);
        });
        
        return app;
    }
}