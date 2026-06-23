using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.Offer;

public sealed record GetOfferMinimalQuery(Guid Id) : IQuery<OfferMinimalDto>;