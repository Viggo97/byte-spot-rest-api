using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Application.Queries.Application;

public sealed record GetApplicationsByOfferIdQuery(Identifier Id) : IQuery<IEnumerable<ApplicationDto>>;