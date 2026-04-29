using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Exceptions.Location;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Location;

public class GetLocationByIdHandler : IQueryHandler<GetLocationByIdQuery, LocationDto>
{
    private readonly ILocationRepository _locationRepository;

    public GetLocationByIdHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task<LocationDto> HandleAsync(GetLocationByIdQuery query)
    {
        var location = await _locationRepository.GetByIdAsync(query.Id);

        return location is null 
            ? throw new LocationByIdNotFoundException(query.Id) 
            : new LocationDto(location.Id, location.Name);
    }
}