using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;

namespace ByteSpot.Infrastructure.DAL.Seeds;

class ExperienceLevelSeeds(ByteSpotDbContext dbContext)
{
    public readonly IReadOnlyCollection<ExperienceLevel> ExperienceLevels =
    [
        ExperienceLevel.Create(1, "Intern"),
        ExperienceLevel.Create(2, "Junior"),
        ExperienceLevel.Create(3, "Regular"),
        ExperienceLevel.Create(4, "Senior"),
        ExperienceLevel.Create(5, "Lead"),
    ];
    
    public readonly IReadOnlyCollection<ExperienceLevelTranslation> ExperienceLevelTranslations =
    [
        ExperienceLevelTranslation.Create(new Identifier("42b8ba74-0005-422f-bb8c-36564130a3a6"), 1, LanguageCode.En, "Intern"),
        ExperienceLevelTranslation.Create(new Identifier("576458f6-bd10-4722-b002-b29427b5aa48"), 2, LanguageCode.En, "Junior"),
        ExperienceLevelTranslation.Create(new Identifier("23518193-a7a0-450a-bffa-8484d57e315b"), 3, LanguageCode.En, "Regular"),
        ExperienceLevelTranslation.Create(new Identifier("562140df-f836-451a-86b8-d953207bfe6c"), 4, LanguageCode.En, "Senior"),
        ExperienceLevelTranslation.Create(new Identifier("7556bec6-956f-43f0-b54c-1d9b08426040"), 5, LanguageCode.En, "Lead"),
        ExperienceLevelTranslation.Create(new Identifier("0feced7c-3d56-460b-9621-3d738c0050c9"), 1, LanguageCode.Pl, "Stażysta"),
        ExperienceLevelTranslation.Create(new Identifier("a79a5841-6433-4953-894c-36fcde70a9bd"), 2, LanguageCode.Pl, "Junior"),
        ExperienceLevelTranslation.Create(new Identifier("944c7f73-c8ea-4e3e-a182-5432fcf112f4"), 3, LanguageCode.Pl, "Regular"),
        ExperienceLevelTranslation.Create(new Identifier("7f9736a6-6150-4124-a9c8-e1e613a817ee"), 4, LanguageCode.Pl, "Senior"),
        ExperienceLevelTranslation.Create(new Identifier("98738df3-3b35-412f-9c04-6aca03df73ba"), 5, LanguageCode.Pl, "Ekspert"),
    ];
    
    public async Task InitAsync()
    {
        if (!dbContext.ExperienceLevels.Any())
        {
            await dbContext.ExperienceLevels.AddRangeAsync(ExperienceLevels);
        }

        if (!dbContext.ExperienceLevelTranslations.Any())
        {
            await dbContext.ExperienceLevelTranslations.AddRangeAsync(ExperienceLevelTranslations);
        }
        
        await dbContext.SaveChangesAsync();
    }
}