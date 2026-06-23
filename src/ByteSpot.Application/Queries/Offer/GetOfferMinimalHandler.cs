using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Exceptions.Offer;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Offer;

internal class GetOfferMinimalHandler : IQueryHandler<GetOfferMinimalQuery, OfferMinimalDto>
{
    private readonly IOfferRepository _offerRepository;

    public GetOfferMinimalHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    public async Task<OfferMinimalDto> HandleAsync(GetOfferMinimalQuery query)
    {
        var offer = await _offerRepository.GetByIdAsync(query.Id);
        return offer == null 
            ? throw new OfferNotFoundException(query.Id) 
            : new OfferMinimalDto(offer.Id, offer.Title);
    }
}