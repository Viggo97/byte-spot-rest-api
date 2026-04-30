using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Technology;

internal sealed class GetTechnologiesHandler : IQueryHandler<GetTechnologiesQuery, IEnumerable<TechnologyDto>>
{
    private readonly ITechnologyRepository _technologyRepository;

    public GetTechnologiesHandler(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }

    public async Task<IEnumerable<TechnologyDto>> HandleAsync(GetTechnologiesQuery query)
    {
        var technologies = await _technologyRepository.GetAllAsync();
        return technologies.Select(technology =>
            new TechnologyDto(technology.Id, technology.Name, technology.IconCode)
        );
    }
}