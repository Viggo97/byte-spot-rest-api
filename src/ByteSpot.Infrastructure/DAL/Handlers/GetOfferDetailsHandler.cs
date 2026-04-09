using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetOfferDetailsHandler(ByteSpotDbContext dbContext)
    : IQueryHandler<GetOfferDetailsQuery, OfferDetailsDto>
{
    public async Task<OfferDetailsDto> HandleAsync(GetOfferDetailsQuery query)
    {
        var offer = await dbContext.Offers
            .AsNoTracking()
            .Include(offer => offer.Company)
            .Include(offer => offer.Locations)
            .Include(offer => offer.Technologies)
            .Include(offer => offer.WorkModes).ThenInclude(m => m.Translations)
            .Include(offer => offer.ExperienceLevels).ThenInclude(l => l.Translations)
            .Include(offer => offer.Salaries).ThenInclude(s => s.EmploymentType).ThenInclude(t => t.Translations)
            .SingleOrDefaultAsync(offer => offer.Id == query.Id);

        if (offer is null)
        {
            throw new NotFoundException($"Not found offer with id {query.Id}.");
        }

        var salaries = offer.Salaries.Select(s => new SalaryDto(
                s.Min, s.Max, s.Fixed, s.Type, s.CurrencyCode, s.BillingUnit,
                new EmploymentTypeDto(s.EmploymentType.Id,
                    s.EmploymentType.Translations.SingleOrDefault(t => t.LanguageCode == query.LanguageCode)!.Name)))
            .OrderBy(s => s.EmploymentType.Id)
            .ToList();
        
        var workModes = offer.WorkModes
            .Select(m => m.Translations.SingleOrDefault(t => t.LanguageCode == query.LanguageCode)!.Name.Value)
            .ToList();

        var experienceLevels = offer.ExperienceLevels.Select(l =>
            l.Translations.SingleOrDefault(t => t.LanguageCode == query.LanguageCode)!.Name.Value).ToList();

        
        return new OfferDetailsDto(
            offer.Id,
            offer.Title,
            new CompanyMinimalDto(offer.Company.Id, offer.Company.Name),
            offer.CreatedAt.ToUnixTimeMilliseconds(),
            offer.ExpiresAt.ToUnixTimeMilliseconds(),
            salaries,
            offer.Locations.Select(l => l.Name.Value).ToList(),
            offer.Technologies.Select(t => t.Name.Value).ToList(),
            workModes,
            experienceLevels,
            "Not implemented"
        );
    }
}