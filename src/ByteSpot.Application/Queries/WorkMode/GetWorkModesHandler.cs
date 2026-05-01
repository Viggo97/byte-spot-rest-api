using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.WorkMode;

internal sealed class GetWorkModesHandler
    : IQueryHandler<GetWorkModesQuery, IEnumerable<WorkModeDto>>
{
    private readonly IWorkModeRepository _workModeRepository;

    public GetWorkModesHandler(IWorkModeRepository workModeRepository)
    {
        _workModeRepository = workModeRepository;
    }
    
    public async Task<IEnumerable<WorkModeDto>> HandleAsync(GetWorkModesQuery query)
    {
        var languageCode = query.LanguageCode;
        var workModes = await _workModeRepository.GetAllAsync();

        return workModes.Select(workMode => new WorkModeDto(
            workMode.Id,
            workMode.Translations.Single(translation => translation.LanguageCode == languageCode).Name
            )
        );
    }
}