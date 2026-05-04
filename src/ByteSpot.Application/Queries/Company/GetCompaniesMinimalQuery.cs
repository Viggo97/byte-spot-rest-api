using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.Company;

public sealed record GetCompaniesMinimalQuery : IQuery<IEnumerable<CompanyMinimalDto>>;