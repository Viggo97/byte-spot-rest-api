using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Handlers;

public sealed class GetLocationsHandler(ILocationRepository locationRepository) 
    : IQueryHandler<GetLocationsQuery, IEnumerable<LocationDto>>
{
    public async Task<IEnumerable<LocationDto>> HandleAsync(GetLocationsQuery query)
    {
        var locations = await locationRepository.GetAllAsync();
        return locations.Select(location => new LocationDto(location.Id, location.Name)).ToList();
    }
}