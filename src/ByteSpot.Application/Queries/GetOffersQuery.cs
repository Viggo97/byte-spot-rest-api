using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries;

public sealed record GetOffersQuery(
    int PageNumber,
    int PageSize,
    OfferSort SortBy,
    bool IsDescending,
    string? SearchPhrase,
    int? SalaryMin,
    int? SalaryMax,
    IEnumerable<Guid>? LocationIds,
    IEnumerable<Guid>? TechnologyIds,
    IEnumerable<int>? WorkModeIds,
    IEnumerable<int>? ExperienceLevelIds,
    IEnumerable<int>? EmploymentTypeIds
    ) : PagedQuery(PageNumber, PageSize), IQuery<PagedResult<OfferDto>>;