using ByteSpot.Api.Utils;
using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class EmploymentTypeEndpoints
{
    private const string Route = "/api/employment-types";
    
    public static WebApplication MapEmploymentTypeEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetEmploymentTypesQuery, IEnumerable<EmploymentTypeDto>> handler,
            HttpContext httpContext) =>
        {
            var languageCode = LanguageCodeConverter.Get(httpContext);
            var query = new GetEmploymentTypesQuery(languageCode);
            var employmentTypes = await handler.HandleAsync(query);
            return Results.Ok(employmentTypes);
        });
        
        return app;
    }
}