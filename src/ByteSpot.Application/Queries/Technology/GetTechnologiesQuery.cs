using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.Technology;

public sealed record GetTechnologiesQuery : IQuery<IEnumerable<TechnologyDto>>;