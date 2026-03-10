using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetWorkModesHandler(ByteSpotDbContext dbContext)
    : IQueryHandler<GetWorkModesQuery, IEnumerable<WorkModeDto>>
{
    public async Task<IEnumerable<WorkModeDto>> HandleAsync(GetWorkModesQuery query)
    {
        var languageCode = query.LanguageCode;
        
        var workModes =
            from workMode in dbContext.WorkModes
            join translation in dbContext.WorkModeTranslations on workMode.Id equals translation.WorkModeId 
            where translation.LanguageCode == languageCode
            select new WorkModeDto(workMode.Id, translation.Name);

        return await workModes.ToListAsync();   
    }
}