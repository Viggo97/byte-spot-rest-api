using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Application.Queries.Offer;

public sealed record GetOfferDetailsQuery : IQuery<OfferDetailsDto>
{
    public Identifier Id { get; }
    public LanguageCode LanguageCode { get; }
    
    public GetOfferDetailsQuery(Guid id, LanguageCode languageCode)
    {
        Id = id;
        LanguageCode = languageCode;
    }
}