using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Commands.Location;

public class AddLocationHandler : ICommandHandler<AddLocationCommand>
{
    private readonly ILocationRepository _locationRepository;

    public AddLocationHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task HandleAsync(AddLocationCommand command)
    {
        var location = Domain.Entities.Location.Create(Guid.NewGuid(), command.Name);
        await _locationRepository.AddAsync(location);
    }
}