using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetOffersHandler(ByteSpotDbContext dbContext)
    : IQueryHandler<GetOffersQuery, PagedResult<OfferDto>>
{
    public async Task<PagedResult<OfferDto>> HandleAsync(GetOffersQuery query)
    {
        var offers = dbContext.Offers.AsNoTracking().AsQueryable();
        var searchPhrase = query.SearchPhrase?.ToLower();

        if (query.SalaryMin is not null)
        {
            offers = offers.Where(offer =>
                offer.Salary.Min >= query.SalaryMin || offer.Salary.Fixed >= query.SalaryMin);
        }

        if (query.SalaryMax is not null)
        {
            offers = offers.Where(offer =>
                offer.Salary.Max <= query.SalaryMax || offer.Salary.Fixed <= query.SalaryMax);
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
            OfferSort.HighestSalary => offers.OrderByDescending(offer => offer.Salary.Max ?? offer.Salary.Fixed).ThenByDescending(offer => offer.Id),
            OfferSort.LowestSalary => offers.OrderBy(offer => offer.Salary.Min ?? offer.Salary.Fixed).ThenBy(offer => offer.Id),
            _ => offers.OrderBy(offer => offer.Title)
        };

        var total = await offers.CountAsync();
        var items = await offers
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(offer =>
                new OfferDto(
                    offer.Id,
                    offer.Title,
                    offer.Company.Name,
                    offer.Salary.Min,
                    offer.Salary.Max,
                    offer.Salary.Fixed,
                    offer.Locations.Select(l => l.Name.Value).ToList(),
                    offer.Technologies.Select(t => t.Name.Value).ToList()
                )
            ).ToListAsync();

        return new PagedResult<OfferDto>(
            Items: items,
            PageNumber: query.PageNumber,
            PageSize: query.PageSize,
            TotalCount: total
        );
    }
}