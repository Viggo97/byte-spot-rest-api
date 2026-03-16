using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetTechnologiesHandler(ByteSpotDbContext dbContext)
    : IQueryHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>>
{
    public async Task<IEnumerable<TechnologyDto>> HandleAsync(GetTechnologiesQuery query)
    {
        return await dbContext.Technologies
            .OrderBy(technology => technology.Name)
            .Select(technology =>
                new TechnologyDto(technology.Id, technology.Name, technology.IconCode)
            )
            .ToListAsync();
    }
}