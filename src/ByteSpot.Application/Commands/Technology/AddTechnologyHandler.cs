using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.Technology;

public class AddTechnologyHandler : ICommandHandler<AddTechnologyCommand>
{
    private readonly ITechnologyRepository _technologyRepository;

    public AddTechnologyHandler(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }
    
    public async Task HandleAsync(AddTechnologyCommand command)
    {
        var technology = Domain.Entities.Technology.Create(Guid.NewGuid(), command.Name, command.IconCode);
        await _technologyRepository.AddAsync(technology);
    }
}
