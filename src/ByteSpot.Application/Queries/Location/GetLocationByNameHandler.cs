using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Exceptions.Location;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Location;

public class GetLocationByNameHandler : IQueryHandler<GetLocationByNameQuery, LocationDto>
{
    private readonly ILocationRepository _locationRepository;

    public GetLocationByNameHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task<LocationDto> HandleAsync(GetLocationByNameQuery query)
    {
        var location = await _locationRepository.GetByNameAsync(query.Name);

        return location is null 
            ? throw new LocationByNameNotFoundException(query.Name) 
            : new LocationDto(location.Id, location.Name);
    }
}