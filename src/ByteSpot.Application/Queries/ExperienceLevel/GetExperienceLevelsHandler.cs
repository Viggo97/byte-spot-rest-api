using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.ExperienceLevel;

internal sealed class GetExperienceLevelsHandler
    : IQueryHandler<GetExperienceLevelsQuery, IEnumerable<ExperienceLevelDto>>
{
    private readonly IExperienceLevelRepository _experienceLevelRepository;

    public GetExperienceLevelsHandler(IExperienceLevelRepository experienceLevelRepository)
    {
        _experienceLevelRepository = experienceLevelRepository;
    }
    
    public async Task<IEnumerable<ExperienceLevelDto>> HandleAsync(GetExperienceLevelsQuery query)
    {
        var languageCode = query.LanguageCode;
        var experienceLevels = await _experienceLevelRepository.GetAllAsync();

        return experienceLevels.Select(experienceLevel => new ExperienceLevelDto(
            experienceLevel.Id,
            experienceLevel.Translations.Single(translation => translation.LanguageCode == languageCode).Name
            )
        );
    }
}
