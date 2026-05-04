using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Company;

public sealed class GetCompaniesMinimalHandler(ICompanyRepository companyRepository) 
    : IQueryHandler<GetCompaniesMinimalQuery, IEnumerable<CompanyMinimalDto>>
{
    public async Task<IEnumerable<CompanyMinimalDto>> HandleAsync(GetCompaniesMinimalQuery query)
    {
        var companies = await companyRepository.GetAllAsync();
        return companies.Select(company => new CompanyMinimalDto(company.Id, company.Name)).ToList();
    }
}