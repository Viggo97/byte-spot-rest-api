using System.Security.Claims;
using ByteSpot.Api.Utils;
using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Commands.Offer;
using ByteSpot.Application.Common;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Application.Queries.Offer;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class OfferEndpoints
{
    private const string Route = "/api/offers";

    public static WebApplication MapOfferEndpoints(this WebApplication app)
    {
        var offersGroup = app.MapGroup(Route).WithTags("Offers");

        offersGroup
            .MapGet("", async (
                [FromServices] IQueryHandler<GetOffersQuery, PagedResult<OfferDto>> handler,
                [FromQuery(Name = "pageNumber")] int? pageNumber,
                [FromQuery(Name = "pageSize")] int? pageSize,
                [FromQuery(Name = "sortBy")] OfferSort? sortBy,
                [FromQuery(Name = "searchPhrase")] string? searchPhrase,
                [FromQuery(Name = "salaryMin")] int? salaryMin,
                [FromQuery(Name = "salaryMax")] int? salaryMax,
                [FromQuery(Name = "locationId")] Guid[]? locationIds,
                [FromQuery(Name = "technologyId")] Guid[]? technologyIds,
                [FromQuery(Name = "workModeId")] int[]? workModeIds,
                [FromQuery(Name = "experienceLevelId")]
                int[]? experienceLevelIds,
                [FromQuery(Name = "employmentTypeId")] int[]? employmentTypeIds) =>
            {
                var offers = await handler.HandleAsync(new GetOffersQuery(
                    PageNumber: pageNumber ?? PagedQuery.DefaultPageNumber,
                    PageSize: pageSize ?? PagedQuery.DefaultPageSize,
                    SortBy: sortBy ?? OfferSort.Latest,
                    SearchPhrase: searchPhrase,
                    SalaryMin: salaryMin,
                    SalaryMax: salaryMax,
                    LocationIds: locationIds,
                    TechnologyIds: technologyIds,
                    WorkModeIds: workModeIds,
                    ExperienceLevelIds: experienceLevelIds,
                    EmploymentTypeIds: employmentTypeIds
                ));
                return Results.Ok(offers);
            });

        offersGroup
            .MapGet("/suggestions", async (
                [FromServices] IQueryHandler<GetOfferSuggestionsQuery, List<OfferSuggestionDto>> handler,
                [FromQuery(Name = "SearchPhrase")] string? searchPhrase) =>
            {
                var suggestions = await handler.HandleAsync(new GetOfferSuggestionsQuery(searchPhrase));
                return Results.Ok(suggestions);
            });
        
        offersGroup
            .MapGet("/company/{id:guid}", async (Guid id, IQueryHandler<GetOffersByCompanyIdQuery, IEnumerable<OfferApplicationDto>> handler) =>
            {
                var offerDetails = await handler.HandleAsync(new GetOffersByCompanyIdQuery(id));
                return Results.Ok(offerDetails);
            });

        offersGroup
            .MapGet("/{id}", async (Guid id, IQueryHandler<GetOfferDetailsQuery, OfferDetailsDto> handler,
                HttpContext httpContext) =>
            {
                var languageCode = LanguageCodeConverter.Get(httpContext);
                var offerDetails = await handler.HandleAsync(new GetOfferDetailsQuery(id, languageCode));
                return Results.Ok(offerDetails);
            });
        
        offersGroup
            .MapGet("/minimal/{id}", async (Guid id, IQueryHandler<GetOfferMinimalQuery, OfferMinimalDto> handler) =>
            {
                var offerMinimal = await handler.HandleAsync(new GetOfferMinimalQuery(id));
                return Results.Ok(offerMinimal);
            });

        offersGroup
            .MapPost("",
                async (AddOfferCommand command, ICommandHandler<AddOfferCommand> handler) =>
                {
                    var cmd = command with { Id = Identifier.Create().Value.ToString() };
                    await handler.HandleAsync(cmd);
                    return Results.Created();
                })
            .RequireAuthorization(builder =>
            {
                builder.RequireRole(Role.Employer(), Role.Recruiter());
            });

        return app;
    }
}