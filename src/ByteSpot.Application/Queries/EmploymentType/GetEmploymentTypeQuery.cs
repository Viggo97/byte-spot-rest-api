using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.EmploymentType;

public sealed record GetEmploymentTypeQuery(int Id) : IQuery<EmploymentTypeWithTranslationsDto>;
