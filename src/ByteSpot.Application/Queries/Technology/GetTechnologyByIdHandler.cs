using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Exceptions.Technology;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Technology;

public class GetTechnologyByIdHandler : IQueryHandler<GetTechnologyByIdQuery, TechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;

    public GetTechnologyByIdHandler(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }
    
    public async Task<TechnologyDto> HandleAsync(GetTechnologyByIdQuery query)
    {
        var technology = await _technologyRepository.GetByIdAsync(query.Id);

        return technology is null
            ? throw new TechnologyNotFoundException(query.Id)
            : new TechnologyDto(technology.Id, technology.Name, technology.IconCode);
    }
}