using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Exceptions.WorkMode;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.WorkMode;

public sealed class UpdateWorkModeHandler: ICommandHandler<UpdateWorkModeCommand>
{
    private readonly IWorkModeRepository _workModeRepository;

    public UpdateWorkModeHandler(IWorkModeRepository workModeRepository)
    {
        _workModeRepository = workModeRepository;
    }
    
    public async Task HandleAsync(UpdateWorkModeCommand command)
    {
        var workMode = await _workModeRepository.GetByIdAsync(command.Id) ?? throw new WorkModeNotFoundException(command.Id);
        
        if (command.Value is not null)
        {
            workMode.ChangeValue(command.Value);
        }
        
        var newTranslations = command.Translations.Select(translation => WorkModeTranslation.Create(
            Guid.NewGuid(),
            workMode.Id,
            translation.LanguageCode,
            translation.Name
        )).ToList();

        var existingTranslations = workMode.Translations
            .ToDictionary(translation => translation.LanguageCode, translation => translation);

        foreach (var translation in newTranslations)
        {
            existingTranslations.TryGetValue(translation.LanguageCode, out var existingTranslation);
            
            if (existingTranslation is null)
            {
                workMode.AddTranslation(translation);
            }
            else
            {
                existingTranslation.ChangeName(translation.Name);
            }
        }
        
        await _workModeRepository.UpdateAsync(workMode);
    }
}