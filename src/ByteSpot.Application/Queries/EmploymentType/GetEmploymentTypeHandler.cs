using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Exceptions.EmploymentType;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.EmploymentType;

public sealed class GetEmploymentTypeHandler : IQueryHandler<GetEmploymentTypeQuery, EmploymentTypeWithTranslationsDto>
{
    private readonly IEmploymentTypeRepository _employmentTypeRepository;

    public GetEmploymentTypeHandler(IEmploymentTypeRepository employmentTypeRepository)
    {
        _employmentTypeRepository = employmentTypeRepository;
    }
    
    public async Task<EmploymentTypeWithTranslationsDto> HandleAsync(GetEmploymentTypeQuery query)
    {
        var employmentType = await _employmentTypeRepository.GetByIdAsync(query.Id);
        
        return employmentType is null 
            ? throw new EmploymentTypeNotFoundException(query.Id) 
            : new EmploymentTypeWithTranslationsDto(
                employmentType.Id,
                employmentType.Value,
                employmentType.Translations.Select(translation => new TranslationDto(
                    translation.Id,
                    translation.Name,
                    translation.LanguageCode
                ))
            );
    }
}
