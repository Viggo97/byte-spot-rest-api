using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Enums;

namespace ByteSpot.Application.Queries;

public sealed record GetEmploymentTypesQuery(LanguageCode LanguageCode) : IQuery<IEnumerable<EmploymentTypeDto>>;