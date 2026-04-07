using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;

namespace ByteSpot.Infrastructure.DAL.Seeds;

class LocationSeeds(ByteSpotDbContext dbContext)
{
    public readonly IReadOnlyCollection<Location> Locations =
    [
        Location.Create(new Identifier("b912639e-5879-43c7-8123-877216cca43a"), "Białystok"),
        Location.Create(new Identifier("f318a9cf-ab02-448d-b5e1-15c9e36778a2"), "Bydgoszcz"),
        Location.Create(new Identifier("9378b8fa-1d2b-4cb9-8d25-4a26e30a948f"), "Gdańsk"),
        Location.Create(new Identifier("6f0d0918-96eb-4251-86b6-1b821f0053a5"), "Gdynia"),
        Location.Create(new Identifier("e6605b31-c1ea-4e4d-924f-4429e208b8f7"), "Gliwice"),
        Location.Create(new Identifier("2e93502b-fd68-453a-a28b-2f347852eca0"), "Gorzów Wielkopolski"),
        Location.Create(new Identifier("cb8f1954-bc48-48f7-a6e5-a0fd99a1bbc5"), "Katowice"),
        Location.Create(new Identifier("0edb215b-694c-4f64-87cb-91c9da2ff504"), "Kielce"),
        Location.Create(new Identifier("ad41c868-5bfd-42e5-b026-a679c9b2d6f4"), "Kraków"),
        Location.Create(new Identifier("ce8dcc2d-cfad-4c74-b759-0ed96b7520c1"), "Lublin"),
        Location.Create(new Identifier("4303dada-caeb-450d-aa1a-c77962460cf1"), "Łódź"),
        Location.Create(new Identifier("fb970b33-cdec-4366-8a18-6fe87244b9e6"), "Poznań"),
        Location.Create(new Identifier("61e9d1f6-4a5c-45e7-b85d-cd482c22b4dd"), "Rzeszów"),
        Location.Create(new Identifier("3bb7951f-5f51-474a-aec9-dd2d0691f517"), "Sopot"),
        Location.Create(new Identifier("98767789-81b8-4cb5-8fee-533eb9966022"), "Szczecin"),
        Location.Create(new Identifier("07d8be70-80fe-49e6-b52c-8349f84cb4ee"), "Toruń"),
        Location.Create(new Identifier("94d6fddc-c4b1-4682-9bf4-15dda444e4af"), "Warszawa"),
        Location.Create(new Identifier("b39b9905-3925-4575-b19e-9937e2ac7167"), "Wrocław"),
        Location.Create(new Identifier("36cc43f3-ed29-4337-adaa-86c7d82e10be"), "Zielona Góra")
    ];
    
    public async Task InitAsync()
    {
        if (!dbContext.Locations.Any())
        {
            await dbContext.Locations.AddRangeAsync(Locations);
            await dbContext.SaveChangesAsync();
        }
    }
}