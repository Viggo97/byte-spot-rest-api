using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Location;

internal sealed class GetLocationsHandler : IQueryHandler<GetLocationsQuery, IEnumerable<LocationDto>>
{
    private readonly ILocationRepository _locationRepository;

    public GetLocationsHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task<IEnumerable<LocationDto>> HandleAsync(GetLocationsQuery query)
    {
        var locations =  await _locationRepository.GetAllAsync();
        return locations.Select(location => new LocationDto(location.Id, location.Name));
    }
}