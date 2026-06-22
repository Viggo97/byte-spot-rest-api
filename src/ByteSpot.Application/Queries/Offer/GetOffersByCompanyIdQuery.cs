using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Application.Queries.Offer;

public sealed record GetOffersByCompanyIdQuery(Identifier Id) : IQuery<IEnumerable<OfferApplicationDto>>;