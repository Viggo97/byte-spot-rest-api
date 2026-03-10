using ByteSpot.Api.Utils;
using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class WorkModeEndpoints
{
    private const string Route = "/api/work-modes";
    
    public static WebApplication MapWorkModeEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetWorkModesQuery, IEnumerable<WorkModeDto>> handler, HttpContext httpContext) =>
        {
            var languageCode = LanguageCodeConverter.Get(httpContext);
            var query = new GetWorkModesQuery(languageCode);
            var workModes = await handler.HandleAsync(query);
            return Results.Ok(workModes);
        });
        
        return app;
    }
}