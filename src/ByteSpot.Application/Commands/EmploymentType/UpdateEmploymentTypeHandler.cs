using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Exceptions.EmploymentType;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.EmploymentType;

public sealed class UpdateEmploymentTypeHandler: ICommandHandler<UpdateEmploymentTypeCommand>
{
    private readonly IEmploymentTypeRepository _employmentTypeRepository;

    public UpdateEmploymentTypeHandler(IEmploymentTypeRepository employmentTypeRepository)
    {
        _employmentTypeRepository = employmentTypeRepository;
    }
    
    public async Task HandleAsync(UpdateEmploymentTypeCommand command)
    {
        var employmentType = await _employmentTypeRepository.GetByIdAsync(command.Id) ?? throw new EmploymentTypeNotFoundException(command.Id);
        
        if (command.Value is not null)
        {
            employmentType.ChangeValue(command.Value);
        }
        
        var newTranslations = command.Translations.Select(translation => EmploymentTypeTranslation.Create(
            Guid.NewGuid(),
            employmentType.Id,
            translation.LanguageCode,
            translation.Name
        )).ToList();

        var existingTranslations = employmentType.Translations
            .ToDictionary(translation => translation.LanguageCode, translation => translation);

        foreach (var translation in newTranslations)
        {
            existingTranslations.TryGetValue(translation.LanguageCode, out var existingTranslation);
            
            if (existingTranslation is null)
            {
                employmentType.AddTranslation(translation);
            }
            else
            {
                existingTranslation.ChangeName(translation.Name);
            }
        }
        
        await _employmentTypeRepository.UpdateAsync(employmentType);
    }
}
