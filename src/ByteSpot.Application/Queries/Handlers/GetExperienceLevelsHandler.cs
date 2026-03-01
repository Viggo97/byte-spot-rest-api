using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Handlers;

public sealed class GetExperienceLevelsHandler(IExperienceLevelRepository experienceLevelRepository)
    : IQueryHandler<GetExperienceLevelsQuery, IEnumerable<ExperienceLevelDto>>
{
    public async Task<IEnumerable<ExperienceLevelDto>> HandleAsync(GetExperienceLevelsQuery query)
    {
        var experienceLevels = await experienceLevelRepository.GetAllAsync();
        return experienceLevels.Select(experienceLevel => new ExperienceLevelDto(experienceLevel.Id, experienceLevel.Name));
    }
}