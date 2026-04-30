using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.Technology;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.Technology;

public class UpdateTechnologyHandler : ICommandHandler<UpdateTechnologyCommand>
{
    private readonly ITechnologyRepository _technologyRepository;

    public UpdateTechnologyHandler(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }
    
    public async Task HandleAsync(UpdateTechnologyCommand command)
    {
        var technology = await _technologyRepository.GetByIdAsync(command.Id);

        if (technology is null)
        {
            throw new TechnologyNotFoundException(command.Id);
        }

        if (technology.Name != command.Name)
        {
            technology.ChangeName(command.Name);
        }
        
        if (technology.IconCode != command.IconCode)
        {
            technology.ChangeIconCode(command.IconCode);
        }
        
        await _technologyRepository.UpdateAsync(technology);
    }
}
