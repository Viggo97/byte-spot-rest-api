using ByteSpot.Infrastructure.DAL.Seeds;

namespace ByteSpot.Infrastructure.DAL.Database;

internal sealed class DatabaseSeeder(ByteSpotDbContext dbContext)
{
    public async Task SeedAsync()
    {
        var companySeeds = new CompanySeeds(dbContext);
        var locationSeeds = new LocationSeeds(dbContext);
        var technologySeeds = new TechnologySeeds(dbContext);
        var workModeSeeds = new WorkModeSeeds(dbContext);
        var experienceLevelSeeds = new ExperienceLevelSeeds(dbContext);
        var employmentTypeSeeds = new EmploymentTypeSeeds(dbContext);
        var offers = new OfferSeeds(dbContext, companySeeds.Companies, locationSeeds.Locations, technologySeeds.Technologies,
            workModeSeeds.WorkModes, experienceLevelSeeds.ExperienceLevels, employmentTypeSeeds.EmploymentTypes);
        
        await companySeeds.InitAsync();
        await locationSeeds.InitAsync();
        await technologySeeds.InitAsync();
        await workModeSeeds.InitAsync();
        await experienceLevelSeeds.InitAsync();
        await employmentTypeSeeds.InitAsync();
        await offers.InitAsync();
    }
}