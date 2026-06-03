using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries.Company;

namespace ByteSpot.Api.Endpoints;

public static class CompanyEndpoints
{
    private const string Route = "/api/companies";

    public static WebApplication MapCompanyEndpoints(this WebApplication app)
    {
        var companiesGroup = app.MapGroup(Route).WithTags("Companies");

        companiesGroup
            .MapGet("/minimal",
                async (IQueryHandler<GetCompaniesMinimalQuery, IEnumerable<CompanyMinimalDto>> handler) =>
                {
                    var companies = await handler.HandleAsync(new GetCompaniesMinimalQuery());
                    return Results.Ok(companies);
                });

        return app;
    }
}