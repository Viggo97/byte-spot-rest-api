using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.EmploymentType;

public sealed class AddEmploymentTypeHandler : ICommandHandler<AddEmploymentTypeCommand>
{
    private readonly IEmploymentTypeRepository _employmentTypeRepository;

    public AddEmploymentTypeHandler(IEmploymentTypeRepository employmentTypeRepository)
    {
        _employmentTypeRepository = employmentTypeRepository;
    }
    
    public async Task HandleAsync(AddEmploymentTypeCommand command)
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
        
        var employmentType = Domain.Entities.EmploymentType.Create(command.Value);
        
        var translations = command.Translations.Select(translation => EmploymentTypeTranslation.Create(
            Guid.NewGuid(),
            employmentType.Id,
            translation.LanguageCode,
            translation.Name
        )).ToList();

        foreach (var translation in translations)
        {
            employmentType.AddTranslation(translation);
        }
        
        await _employmentTypeRepository.AddAsync(employmentType);
    }
}
