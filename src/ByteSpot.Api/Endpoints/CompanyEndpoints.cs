using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.Company;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries.Company;
using ByteSpot.Domain.ValueObjects.Shared;

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

        companiesGroup
            .MapPost("", async (AddCompanyCommand command, ICommandHandler<AddCompanyCommand> handler) =>
            {
                var id = new Identifier(Guid.NewGuid());
                var cmd = command with { Id = id.Value.ToString() };
                await handler.HandleAsync(cmd);
                return Results.Created(id.Value.ToString(), null);
            });

        return app;
    }
}