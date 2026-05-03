using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.EmploymentType;

public sealed class GetEmploymentTypesHandler : IQueryHandler<GetEmploymentTypesQuery, IEnumerable<EmploymentTypeDto>>
{
    private readonly IEmploymentTypeRepository _employmentTypeRepository;

    public GetEmploymentTypesHandler(IEmploymentTypeRepository employmentTypeRepository)
    {
        _employmentTypeRepository = employmentTypeRepository;
    }
    
    public async Task<IEnumerable<EmploymentTypeDto>> HandleAsync(GetEmploymentTypesQuery query)
    {
        var languageCode = query.LanguageCode;
        var employmentTypes = await _employmentTypeRepository.GetAllAsync();

        return employmentTypes.Select(employmentType => new EmploymentTypeDto(
                employmentType.Id,
                employmentType.Translations.Single(translation => translation.LanguageCode == languageCode).Name
            )
        );
    }
}