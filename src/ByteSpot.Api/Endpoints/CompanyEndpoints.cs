using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class CompanyEndpoints
{
    private const string Route = "/api/companies";
    
    public static WebApplication MapCompanyEndpoints(this WebApplication app)
    {
        app.MapGet($"{Route}/minimal", async (IQueryHandler<GetCompaniesMinimalQuery, IEnumerable<CompanyMinimalDto>> handler) =>
        {
            var companies = await handler.HandleAsync(new GetCompaniesMinimalQuery());
            return Results.Ok(companies);
        });
        
        return app;
    }
}