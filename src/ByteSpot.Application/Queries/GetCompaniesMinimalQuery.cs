using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries;

public sealed record GetCompaniesMinimalQuery : IQuery<IEnumerable<CompanyMinimalDto>>;