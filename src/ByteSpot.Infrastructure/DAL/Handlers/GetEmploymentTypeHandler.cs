using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetEmploymentTypeHandler(ByteSpotDbContext dbContext)
    : IQueryHandler<GetEmploymentTypesQuery, IEnumerable<EmploymentTypeDto>>
{
    public async Task<IEnumerable<EmploymentTypeDto>> HandleAsync(GetEmploymentTypesQuery query)
    {
        var languageCode = query.LanguageCode;
        
        var employmentTypes =
            from employmentType in dbContext.EmploymentTypes
            join translation in dbContext.EmploymentTypeTranslations on employmentType.Id equals translation.EmploymentTypeId 
            where translation.LanguageCode == languageCode
            select new EmploymentTypeDto(employmentType.Id, translation.Name);

        return await employmentTypes.ToListAsync();
    }
}