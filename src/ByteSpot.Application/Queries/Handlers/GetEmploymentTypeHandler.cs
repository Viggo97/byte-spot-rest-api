using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Handlers;

public sealed class GetEmploymentTypeHandler(IEmploymentTypeRepository employmentTypeRepository)
    : IQueryHandler<GetEmploymentTypesQuery, IEnumerable<EmploymentTypeDto>>
{
    public async Task<IEnumerable<EmploymentTypeDto>> HandleAsync(GetEmploymentTypesQuery query)
    {
        var employmentTypes = await employmentTypeRepository.GetAllAsync();
        return employmentTypes.Select(employmentType => new EmploymentTypeDto(employmentType.Id, employmentType.Name));
    }
}