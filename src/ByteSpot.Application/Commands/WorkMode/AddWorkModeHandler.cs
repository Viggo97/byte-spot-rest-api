using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.WorkMode;

public sealed class AddWorkModeHandler : ICommandHandler<AddWorkModeCommand>
{
    private readonly IWorkModeRepository _workModeRepository;

    public AddWorkModeHandler(IWorkModeRepository workModeRepository)
    {
        _workModeRepository = workModeRepository;
    }
    
    public async Task HandleAsync(AddWorkModeCommand command)
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
        
        var workMode = Domain.Entities.WorkMode.Create(command.Value);
        
        var translations = command.Translations.Select(translation => WorkModeTranslation.Create(
            Guid.NewGuid(),
            workMode.Id,
            translation.LanguageCode,
            translation.Name
        )).ToList();

        foreach (var translation in translations)
        {
            workMode.AddTranslation(translation);
        }
        
        await _workModeRepository.AddAsync(workMode);
    }
}