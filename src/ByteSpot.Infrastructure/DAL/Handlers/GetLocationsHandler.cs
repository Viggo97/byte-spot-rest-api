using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetLocationsHandler(ByteSpotDbContext dbContext) 
    : IQueryHandler<GetLocationsQuery, IEnumerable<LocationDto>>
{
    public async Task<IEnumerable<LocationDto>> HandleAsync(GetLocationsQuery query)
    {
        return await dbContext.Locations
            .OrderBy(location => location.Name)
            .Select(location => new LocationDto(location.Id, location.Name))
            .ToListAsync();
    }
}