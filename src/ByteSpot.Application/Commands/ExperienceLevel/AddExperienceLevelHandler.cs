using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.ExperienceLevel;

public sealed class AddExperienceLevelHandler : ICommandHandler<AddExperienceLevelCommand>
{
    private readonly IExperienceLevelRepository _experienceLevelRepository;

    public AddExperienceLevelHandler(IExperienceLevelRepository experienceLevelRepository)
    {
        _experienceLevelRepository = experienceLevelRepository;
    }
    
    public async Task HandleAsync(AddExperienceLevelCommand command)
    {
        var hasTranslations = command.Translations.Count == Enum.GetValues<LanguageCode>().Length;
        if (!hasTranslations)
        {
            throw new NoTranslationProvidedException();
        }

        var hasEnglishTranslation = command.Translations.Any(translation => translation.LanguageCode == LanguageCode.En);
        if (!hasEnglishTranslation)
        {
            throw new NoEnglishTranslationProvidedException();
        }
        
        var experienceLevel = Domain.Entities.ExperienceLevel.Create(command.Value);
        
        var translations = command.Translations.Select(translation => ExperienceLevelTranslation.Create(
            Guid.NewGuid(),
            experienceLevel.Id,
            translation.LanguageCode,
            translation.Name
        )).ToList();

        foreach (var translation in translations)
        {
            experienceLevel.AddTranslation(translation);
        }
        
        await _experienceLevelRepository.AddAsync(experienceLevel);
    }
}
