using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Handlers;

public sealed class GetWorkModesHandler(IWorkModeRepository workModeRepository)
    : IQueryHandler<GetWorkModesQuery, IEnumerable<WorkModeDto>>
{
    public async Task<IEnumerable<WorkModeDto>> HandleAsync(GetWorkModesQuery query)
    {
        var workModes = await workModeRepository.GetAllAsync();
        return workModes.Select(workMode => new WorkModeDto(workMode.Id, workMode.Name));
    }
}