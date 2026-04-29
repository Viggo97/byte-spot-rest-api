using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.Location;

public sealed record GetLocationByNameQuery(string Name) : IQuery<LocationDto>;