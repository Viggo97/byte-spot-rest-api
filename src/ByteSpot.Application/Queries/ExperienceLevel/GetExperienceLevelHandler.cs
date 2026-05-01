using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Exceptions.ExperienceLevel;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.ExperienceLevel;

public sealed class GetExperienceLevelHandler : IQueryHandler<GetExperienceLevelQuery, ExperienceLevelWithTranslationsDto>
{
    private readonly IExperienceLevelRepository _experienceLevelRepository;

    public GetExperienceLevelHandler(IExperienceLevelRepository experienceLevelRepository)
    {
        _experienceLevelRepository = experienceLevelRepository;
    }
    
    public async Task<ExperienceLevelWithTranslationsDto> HandleAsync(GetExperienceLevelQuery query)
    {
        var experienceLevel = await _experienceLevelRepository.GetByIdAsync(query.Id);
        
        return experienceLevel is null 
            ? throw new ExperienceLevelNotFoundException(query.Id) 
            : new ExperienceLevelWithTranslationsDto(
                experienceLevel.Id,
                experienceLevel.Value,
                experienceLevel.Translations.Select(translation => new TranslationDto(
                    translation.Id,
                    translation.Name,
                    translation.LanguageCode
                ))
            );
    }
}
