using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;

namespace ByteSpot.Infrastructure.DAL.Seeds;

class WorkModeSeeds(ByteSpotDbContext dbContext)
{
    public readonly IReadOnlyCollection<WorkMode> WorkModes =
    [
        WorkMode.Create(1, "OnSite"),
        WorkMode.Create(2, "Hybrid"),
        WorkMode.Create(3, "Remote"),
    ];

    public readonly IReadOnlyCollection<WorkModeTranslation> WorkModeTranslations =
    [
        WorkModeTranslation.Create(new Identifier("b792decb-3f83-4f2a-a3a3-839d2b21713c"), 1, LanguageCode.En,
            "On site"),
        WorkModeTranslation.Create(new Identifier("ffb3b8d2-5a7e-4f1e-9399-52bd465441b5"), 1, LanguageCode.Pl,
            "Stacjonarnie"),
        WorkModeTranslation.Create(new Identifier("fc99cafe-9774-4e63-809e-9cd842cb8b30"), 2, LanguageCode.En,
            "Hybrid"),
        WorkModeTranslation.Create(new Identifier("1af8d3f3-bf4a-4307-986a-78241b74629e"), 2, LanguageCode.Pl,
            "Hybrydowo"),
        WorkModeTranslation.Create(new Identifier("68a39f47-8897-490a-ae3d-8e2d57f1ac27"), 3, LanguageCode.En,
            "Remote"),
        WorkModeTranslation.Create(new Identifier("8cbb76f4-2c13-476d-8864-0652fedd571d"), 3, LanguageCode.Pl,
            "Zdalnie"),
    ];
    
    public async Task InitAsync()
    {
        if (!dbContext.WorkModes.Any())
        {
            await dbContext.WorkModes.AddRangeAsync(WorkModes);
        }

        if (!dbContext.WorkModeTranslations.Any())
        {
            await dbContext.WorkModeTranslations.AddRangeAsync(WorkModeTranslations);
        }
        
        await dbContext.SaveChangesAsync();
    }
}