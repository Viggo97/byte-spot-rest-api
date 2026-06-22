using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Offer;

internal sealed class GetOffersByCompanyIdHandler : IQueryHandler<GetOffersByCompanyIdQuery, IEnumerable<OfferApplicationDto>>
{
    private readonly IOfferRepository _offerRepository;

    public GetOffersByCompanyIdHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    public async Task<IEnumerable<OfferApplicationDto>> HandleAsync(GetOffersByCompanyIdQuery query)
    {
        var offers = await _offerRepository.GetAllByCompanyIdAsync(query.Id);
        return offers.Select(offer => new OfferApplicationDto(offer.Id, offer.Title, offer.ExpiresAt.ToUnixTimeMilliseconds()));
    }
}