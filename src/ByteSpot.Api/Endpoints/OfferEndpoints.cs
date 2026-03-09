using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ByteSpot.Api.Endpoints;

public static class OfferEndpoints
{
    private const string Route = "/api/offers";

    public static WebApplication MapOfferEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (
            [FromServices] IQueryHandler<GetOffersQuery, PagedResult<OfferDto>> handler,
            [FromQuery(Name = "pageNumber")] int? pageNumber,
            [FromQuery(Name = "pageSize")] int? pageSize,
            [FromQuery(Name = "sortBy")] OfferSort? sortBy,
            [FromQuery(Name = "isDescending")] bool? isDescending,
            [FromQuery(Name = "searchPhrase")] string? searchPhrase,
            [FromQuery(Name = "salaryMin")] int? salaryMin,
            [FromQuery(Name = "salaryMax")] int? salaryMax,
            [FromQuery(Name = "locationId")] Guid[]? locationIds,
            [FromQuery(Name = "technologyId")] Guid[]? technologyIds,
            [FromQuery(Name = "workModeId")] int[]? workModeIds,
            [FromQuery(Name = "experienceLevelId")] int[]? experienceLevelIds,
            [FromQuery(Name = "employmentTypeId")] int[]? employmentTypeIds) =>
        {
            var offers = await handler.HandleAsync(new GetOffersQuery(
                PageNumber: pageNumber ?? PagedQuery.DefaultPageNumber,
                PageSize: pageSize ?? PagedQuery.DefaultPageSize,
                SortBy: sortBy ?? OfferSort.Latest,
                SearchPhrase: searchPhrase,
                IsDescending: isDescending ?? false,
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

        app.MapGet($"{Route}/suggestions", async (
            [FromServices] IQueryHandler<GetOfferSuggestionsQuery, List<OfferSuggestionDto>> handler,
            [FromQuery(Name = "SearchPhrase")] string? searchPhrase) =>
        {
          var suggestions = await handler.HandleAsync(new GetOfferSuggestionsQuery(searchPhrase));
            return Results.Ok(suggestions);
        });

        return app;
    }
}