using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.ExperienceLevel;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.ExperienceLevel;

public sealed class RemoveExperienceLevelHandler : ICommandHandler<RemoveExperienceLevelCommand>
{
    private readonly IExperienceLevelRepository _experienceLevelRepository;

    public RemoveExperienceLevelHandler(IExperienceLevelRepository experienceLevelRepository)
    {
        _experienceLevelRepository = experienceLevelRepository;
    }
    
    public async Task HandleAsync(RemoveExperienceLevelCommand command)
    {
        var experienceLevel = await _experienceLevelRepository.GetByIdAsync(command.Id) ?? throw new ExperienceLevelNotFoundException(command.Id);
        
        await _experienceLevelRepository.RemoveAsync(command.Id);
    }
}
