using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;

namespace ByteSpot.Infrastructure.DAL.Seeds;

class EmploymentTypeSeeds(ByteSpotDbContext dbContext)
{
    public readonly IReadOnlyCollection<EmploymentType> EmploymentTypes =
    [
        EmploymentType.Create(1, "EmploymentContract"),
        EmploymentType.Create(2, "B2B"),
        EmploymentType.Create(3, "MandateContract"),
        EmploymentType.Create(4, "SpecificTaskContract"),
        EmploymentType.Create(5, "Internship"),
    ];
    
    public readonly IReadOnlyCollection<EmploymentTypeTranslation> EmploymentTypeTranslations =
    [
        EmploymentTypeTranslation.Create(new Identifier("8530df43-152f-46e7-a4cd-7346a78c169a"), 1, LanguageCode.En, "Employment contract"),
        EmploymentTypeTranslation.Create(new Identifier("56f52b91-5452-4d8b-a091-4be377536ec9"), 2, LanguageCode.En, "B2B"),
        EmploymentTypeTranslation.Create(new Identifier("065a9147-710a-4a5c-b84f-f85a9a5b5622"), 3, LanguageCode.En, "Mandate contract"),
        EmploymentTypeTranslation.Create(new Identifier("9aab7899-3e7a-4495-b933-2a4cbed8294d"), 4, LanguageCode.En, "Specific task contract"),
        EmploymentTypeTranslation.Create(new Identifier("0ac661c5-a55b-4b74-b4e9-5815a0c8674e"), 5, LanguageCode.En, "Internship"),
        EmploymentTypeTranslation.Create(new Identifier("04b871b3-3649-4ac9-a536-089f8830c50c"), 1, LanguageCode.Pl, "Umowa o pracę"),
        EmploymentTypeTranslation.Create(new Identifier("5229d196-3491-447e-983d-c0e4d5c2ab96"), 2, LanguageCode.Pl, "B2B"),
        EmploymentTypeTranslation.Create(new Identifier("7462bfa3-d0d8-4cd3-9902-1e83156c679c"), 3, LanguageCode.Pl, "Umowa zlecenie"),
        EmploymentTypeTranslation.Create(new Identifier("e87e3808-2aae-4f2f-abaf-57d805af5b9c"), 4, LanguageCode.Pl, "Umowa o dzieło"),
        EmploymentTypeTranslation.Create(new Identifier("7b5a8e53-dffc-4654-b85a-b8244452b757"), 5, LanguageCode.Pl, "Staż"),
    ];
    
    public async Task InitAsync()
    {
        if (!dbContext.EmploymentTypes.Any())
        {
            await dbContext.EmploymentTypes.AddRangeAsync(EmploymentTypes);
        }

        if (!dbContext.EmploymentTypeTranslations.Any())
        {
            await dbContext.EmploymentTypeTranslations.AddRangeAsync(EmploymentTypeTranslations);
        }
        
        await dbContext.SaveChangesAsync();
    }
}