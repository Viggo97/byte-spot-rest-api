using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;

namespace ByteSpot.Infrastructure.DAL.Seeds;

class CompanySeeds(ByteSpotDbContext dbContext)
{
    public readonly IReadOnlyCollection<Company> Companies =
    [
        Company.Create(new Identifier("cfdc385e-6ce6-41df-9b9e-1538450c824c"), "Amazon"),
        Company.Create(new Identifier("c3fe179a-5e81-4e18-8c59-f53519187afa"), "Apple"),
        Company.Create(new Identifier("5c1f5397-93b9-4e8f-bc78-f5ce56de46ff"), "Google"),
        Company.Create(new Identifier("2febbdb9-5874-4968-bdd5-d7089fde7b13"), "Meta"),
        Company.Create(new Identifier("893ce20d-329c-4417-b68f-54a01572ab2d"), "Microsoft"),
        Company.Create(new Identifier("0cbde627-f281-49d4-8a89-5525a8776cf5"), "Netflix"),
        Company.Create(new Identifier("f371e4a6-016e-4d30-bbd9-08eef2e3dcc1"), "Oracle"),
    ];
    
    public async Task InitAsync()
    {
        if (!dbContext.Companies.Any())
        {
            await dbContext.Companies.AddRangeAsync(Companies);
            await dbContext.SaveChangesAsync();
        }
    }
}