using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.Exceptions.Offer;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Offer;

internal sealed class GetOfferDetailsHandler
    : IQueryHandler<GetOfferDetailsQuery, OfferDetailsDto>
{
    private readonly IOfferRepository _offerRepository;

    public GetOfferDetailsHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    public async Task<OfferDetailsDto> HandleAsync(GetOfferDetailsQuery query)
    {
        var offer = await _offerRepository.GetByIdAsync(query.Id);

        if (offer is null)
        {
            throw new OfferNotFoundException(query.Id);
        }

        var salaries = offer.Salaries.Select(s => new SalaryDto(
                s.Min, s.Max, s.Fixed, s.Type, s.CurrencyCode, s.BillingUnit,
                new EmploymentTypeDto(s.EmploymentType.Id.ToString(),
                    s.EmploymentType.Translations.SingleOrDefault(t => t.LanguageCode == query.LanguageCode)!.Name)))
            .OrderBy(s => s.EmploymentType.Id)
            .ToList();

        var workModes = offer.WorkModes
            .Select(workMode =>
            {
                var translation =
                    workMode.Translations.SingleOrDefault(t => t.LanguageCode == query.LanguageCode)
                    ?? workMode.Translations.Single(t => t.LanguageCode == LanguageCode.En);
                return translation.Name.Value;
            })
            .ToList();

        var experienceLevels = offer.ExperienceLevels
            .Select(experienceLevel =>
            {
                var translation =
                    experienceLevel.Translations.SingleOrDefault(t => t.LanguageCode == query.LanguageCode)
                    ?? experienceLevel.Translations.Single(t => t.LanguageCode == LanguageCode.En);
                return translation.Name.Value;
            })
            .ToList();


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
            offer.Description
        );
    }
}