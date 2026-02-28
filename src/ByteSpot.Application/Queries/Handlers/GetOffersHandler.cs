using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Handlers;

public sealed class GetOffersHandler(IOfferRepository offerRepository)
    : IQueryHandler<GetOffersQuery, IEnumerable<OfferDto>>
{
    public async Task<IEnumerable<OfferDto>> HandleAsync(GetOffersQuery query)
    {
        var offers = await offerRepository.GetAllAsync();
            
        return offers.Select(offer =>
            {
                var tmp = new OfferDto(
                    offer.Id,
                    offer.Title,
                    offer.Company.Name,
                    offer.Salary.Min,
                    offer.Salary.Max,
                    offer.Salary.Fixed,
                    offer.Locations.Select(l => l.Name.Value).ToList(),
                    offer.Technologies.Select(t => t.Name.Value).ToList()
                );
                return tmp;
            }
            
        ).ToList();
    }
}