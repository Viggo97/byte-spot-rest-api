using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Handlers;

public sealed class GetTechnologiesHandler(ITechnologyRepository technologyRepository)
    : IQueryHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>>
{
    public async Task<IEnumerable<TechnologyDto>> HandleAsync(GetTechnologiesQuery query)
    {
        var technologies = await technologyRepository.GetAllAsync();
        return technologies.Select(technology =>
            new TechnologyDto(technology.Id, technology.Name, technology.IconCode)
        ).ToList();
    }
}