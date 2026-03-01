using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class EmploymentTypeEndpoints
{
    private const string Route = "/api/employment-types";
    
    public static WebApplication MapEmploymentTypeEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetEmploymentTypesQuery, IEnumerable<EmploymentTypeDto>> handler) =>
        {
            var employmentTypes = await handler.HandleAsync(new GetEmploymentTypesQuery());
            return Results.Ok(employmentTypes);
        });
        
        return app;
    }
}