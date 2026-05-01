using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Exceptions.WorkMode;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.WorkMode;

public sealed class GetWorkModeHandler : IQueryHandler<GetWorkModeQuery, WorkModeWithTranslationsDto>
{
    private readonly IWorkModeRepository _workModeRepository;

    public GetWorkModeHandler(IWorkModeRepository workModeRepository)
    {
        _workModeRepository = workModeRepository;
    }
    
    public async Task<WorkModeWithTranslationsDto> HandleAsync(GetWorkModeQuery query)
    {
        var workMode = await _workModeRepository.GetByIdAsync(query.Id);
        
        return workMode is null 
            ? throw new WorkModeNotFoundException(query.Id) 
            : new WorkModeWithTranslationsDto(
                workMode.Id,
                workMode.Value,
                workMode.Translations.Select(translation => new TranslationDto(
                    translation.Id,
                    translation.Name,
                    translation.LanguageCode
                ))
            );
    }
}