using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries;

public sealed record GetEmploymentTypesQuery() : IQuery<IEnumerable<EmploymentTypeDto>>;