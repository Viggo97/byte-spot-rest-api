using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetExperienceLevelsHandler(ByteSpotDbContext dbContext)
    : IQueryHandler<GetExperienceLevelsQuery, IEnumerable<ExperienceLevelDto>>
{
    public async Task<IEnumerable<ExperienceLevelDto>> HandleAsync(GetExperienceLevelsQuery query)
    {
        var languageCode = query.LanguageCode;
        
        var experienceLevels =
            from experienceLevel in dbContext.ExperienceLevels
            join translation in dbContext.ExperienceLevelTranslations on experienceLevel.Id equals translation.ExperienceLevelId 
            where translation.LanguageCode == languageCode
            select new ExperienceLevelDto(experienceLevel.Id, translation.Name);

        return await experienceLevels.ToListAsync();  
    }
}