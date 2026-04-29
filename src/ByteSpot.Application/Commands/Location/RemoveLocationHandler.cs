using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.Location;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.Location;

public class RemoveLocationHandler : ICommandHandler<RemoveLocationCommand>
{
    private readonly ILocationRepository _locationRepository;

    public RemoveLocationHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task HandleAsync(RemoveLocationCommand command)
    {
        var location = await _locationRepository.GetByIdAsync(command.Id);

        if (location is null)
        {
            throw new LocationByIdNotFoundException(command.Id);
        }

        await _locationRepository.RemoveAsync(command.Id);
    }
}