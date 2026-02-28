using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries;

public sealed record GetOffersQuery() : IQuery<IEnumerable<OfferDto>>;