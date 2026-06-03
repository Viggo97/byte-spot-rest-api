using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Offer;

public sealed class GetOffersHandler : IQueryHandler<GetOffersQuery, PagedResult<OfferDto>>
{
    private readonly IOfferRepository _offerRepository;

    public GetOffersHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    public async Task<PagedResult<OfferDto>> HandleAsync(GetOffersQuery query)
    {
        var offers = _offerRepository.GetAllAsync();
        var searchPhrase = query.SearchPhrase?.ToLower();

        if (query.SalaryMin is not null)
        {
            offers = offers.Where(offer => offer.SalaryMinComputed >= query.SalaryMin);
        }

        if (query.SalaryMax is not null)
        {
            offers = offers.Where(offer => offer.SalaryMaxComputed<= query.SalaryMax);
        }

        if (query.LocationIds is not null && query.LocationIds.Any())
        {
            offers = offers.Where(offer => offer.Locations.Any(location => query.LocationIds.Contains(location.Id)));
        }

        if (query.TechnologyIds is not null && query.TechnologyIds.Any())
        {
            offers = offers.Where(offer =>
                offer.Technologies.Any(technology => query.TechnologyIds.Contains(technology.Id)));
        }

        if (query.WorkModeIds is not null && query.WorkModeIds.Any())
        {
            offers = offers.Where(offer => offer.WorkModes.Any(workMode => query.WorkModeIds.Contains(workMode.Id)));
        }

        if (query.ExperienceLevelIds is not null && query.ExperienceLevelIds.Any())
        {
            offers = offers.Where(offer =>
                offer.ExperienceLevels.Any(experienceLevel => query.ExperienceLevelIds.Contains(experienceLevel.Id)));
        }

        if (query.EmploymentTypeIds is not null && query.EmploymentTypeIds.Any())
        {
            offers = offers.Where(offer =>
                offer.EmploymentTypes.Any(employmentType => query.EmploymentTypeIds.Contains(employmentType.Id)));
        }
        
        if (searchPhrase is not null)
        {
            offers = offers.Where(offer => ((string)offer.Title).ToLower().Contains(searchPhrase)
                                           || offer.Locations.Any(location => ((string)location.Name).ToLower().Contains(searchPhrase))
                                           || offer.Technologies.Any(technology => ((string)technology.Name).ToLower().Contains(searchPhrase))
                                           || ((string)offer.Company.Name).ToLower().Contains(searchPhrase));
        }

        offers = query.SortBy switch
        {
            OfferSort.Latest => offers.OrderByDescending(offer => offer.CreatedAt).ThenByDescending(offer => offer.Id),
            OfferSort.HighestSalary => offers.OrderByDescending(offer => offer.SalaryMaxComputed).ThenByDescending(offer => offer.CreatedAt).ThenByDescending(offer => offer.Id),
            OfferSort.LowestSalary => offers.OrderBy(offer => offer.SalaryMinComputed).ThenByDescending(offer => offer.CreatedAt).ThenBy(offer => offer.Id),
            _ => offers.OrderBy(offer => offer.Title)
        };
        
        var totalCount = offers.Count();

        var items = offers
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(offer => new OfferDto(
                    offer.Id,
                    offer.Title,
                    offer.Company.Name,
                    offer.Salaries.Select(s => new SalaryDto(s.Min, s.Max, s.Fixed, s.Type, s.CurrencyCode,
                        s.BillingUnit, new EmploymentTypeDto(s.EmploymentType.Id.ToString(), s.EmploymentType.Value))).ToList(),
                    offer.Locations.Select(l => l.Name.Value).ToList(),
                    offer.Technologies.Select(t => t.Name.Value).ToList()
                )
            ).ToList();
        
        return new PagedResult<OfferDto>(
            Items: items,
            PageNumber: query.PageNumber,
            PageSize: query.PageSize,
            TotalCount: totalCount
        );
    }
}