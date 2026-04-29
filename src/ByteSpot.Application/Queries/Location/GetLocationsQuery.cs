using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.Location;

public sealed record GetLocationsQuery : IQuery<IEnumerable<LocationDto>>;