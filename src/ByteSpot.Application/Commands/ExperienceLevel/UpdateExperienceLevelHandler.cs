using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Exceptions.ExperienceLevel;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.ExperienceLevel;

public sealed class UpdateExperienceLevelHandler: ICommandHandler<UpdateExperienceLevelCommand>
{
    private readonly IExperienceLevelRepository _experienceLevelRepository;

    public UpdateExperienceLevelHandler(IExperienceLevelRepository experienceLevelRepository)
    {
        _experienceLevelRepository = experienceLevelRepository;
    }
    
    public async Task HandleAsync(UpdateExperienceLevelCommand command)
    {
        var experienceLevel = await _experienceLevelRepository.GetByIdAsync(command.Id) ?? throw new ExperienceLevelNotFoundException(command.Id);
        
        if (command.Value is not null)
        {
            experienceLevel.ChangeValue(command.Value);
        }
        
        var newTranslations = command.Translations.Select(translation => ExperienceLevelTranslation.Create(
            Guid.NewGuid(),
            experienceLevel.Id,
            translation.LanguageCode,
            translation.Name
        )).ToList();

        var existingTranslations = experienceLevel.Translations
            .ToDictionary(translation => translation.LanguageCode, translation => translation);

        foreach (var translation in newTranslations)
        {
            existingTranslations.TryGetValue(translation.LanguageCode, out var existingTranslation);
            
            if (existingTranslation is null)
            {
                experienceLevel.AddTranslation(translation);
            }
            else
            {
                existingTranslation.ChangeName(translation.Name);
            }
        }
        
        await _experienceLevelRepository.UpdateAsync(experienceLevel);
    }
}
