using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.Technology;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.Technology;

public class RemoveTechnologyHandler : ICommandHandler<RemoveTechnologyCommand>
{
    private readonly ITechnologyRepository _technologyRepository;

    public RemoveTechnologyHandler(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }
    
    public async Task HandleAsync(RemoveTechnologyCommand command)
    {
        var technology = await _technologyRepository.GetByIdAsync(command.Id);

        if (technology is null)
        {
            throw new TechnologyNotFoundException(command.Id);
        }

        await _technologyRepository.RemoveAsync(command.Id);
    }
}
