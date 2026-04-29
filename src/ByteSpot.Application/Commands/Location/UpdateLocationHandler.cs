using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Exceptions.Location;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.Location;

public class UpdateLocationHandler : ICommandHandler<UpdateLocationCommand>
{
    private readonly ILocationRepository _locationRepository;

    public UpdateLocationHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task HandleAsync(UpdateLocationCommand command)
    {
        var location = await _locationRepository.GetByIdAsync(command.Id);

        if (location is null)
        {
            throw new LocationByIdNotFoundException(command.Id);
        }

        location.ChangeName(command.Name);
        
        await _locationRepository.UpdateAsync(location);
    }
}