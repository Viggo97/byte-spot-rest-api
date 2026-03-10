using System.Text;
using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Database;

internal sealed class DatabaseSeeder(ByteSpotDbContext dbContext)
{
    public async Task SeedAsync()
    {
        await AddCompanies();
        await AddLocations();
        await AddTechnologies();
        await AddWorkModes();
        await AddWorkModeTranslations();
        await AddExperienceLevels();
        await AddEmploymentTypes();
        await AddOffers();
    }

    private async Task AddOffers()
    {
        if (!dbContext.Offers.Any())
        {
            var locations = await dbContext.Locations.ToListAsync();
            var technologies = await dbContext.Technologies.ToListAsync();
            var companies = await dbContext.Companies.ToListAsync();
            var workModes = await dbContext.WorkModes.ToListAsync();
            var experienceLevels = await dbContext.ExperienceLevels.ToListAsync();
            var employmentTypes = await dbContext.EmploymentTypes.ToListAsync();
            
            var offers = new List<Offer>()
            {
                CreateOffer(
                    new Identifier("cd11aea2-9a6c-4462-b16b-570d75247129"),
                    "JavaScript Developer",
                    new Salary(12_000, 18_000),
                    companies[0].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 1, 0, TimeSpan.Zero),
                    ["Warszawa", "Bydgoszcz"],
                    ["JavaScript", "TypeScript"],
                    ["Remote", "Hybrid"],
                    ["Regular"],
                    ["EmploymentContract", "B2B"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("df08859f-df88-45bb-b59a-cd856e578f16"),
                    "Java Developer",
                    new Salary(13_000, 16_000),
                    companies[1].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 2, 0, TimeSpan.Zero),
                    ["Wrocław"],
                    ["Java", "Mobile"],
                    ["Hybrid", "OnSite"],
                    ["Regular", "Senior"],
                    ["B2B", "MandateContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("8cae5d4f-eb4a-4a15-b504-6ee321ee1534"),
                    "Senior C# Developer",
                    new Salary(18_500),
                    companies[2].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 3, 0, TimeSpan.Zero),
                    ["Kraków", "Wrocław", "Warszawa", "Poznań", "Gdańsk", "Katowice", "Łódź"],
                    ["C#", "SQL", "Azure"],
                    ["Remote"],
                    ["Senior"],
                    ["B2B"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("db657ff0-115b-484b-b19a-51704e8dbc93"),
                    "Junior Go Developer",
                    new Salary(12_000),
                    companies[3].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 4, 0, TimeSpan.Zero),
                    ["Kraków"],
                    ["Go", "Python"],
                    ["OnSite"],
                    ["Intern", "Junior"],
                    ["MandateContract", "SpecificTaskContract", "Internship"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("f46fc3a8-be21-4451-91e4-45015f71e4df"),
                    "Python Developer",
                    new Salary(13_500, 19_000),
                    companies[4].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 5, 0, TimeSpan.Zero),
                    ["Toruń", "Poznań"],
                    ["SQL", "Python"],
                    ["Hybrid"],
                    ["Regular", "Senior"],
                    ["EmploymentContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("87ab8cad-f4a7-4e7e-a174-b8618c93ecf5"),
                    "Senior Java Developer",
                    new Salary(14_500, 17_500),
                    companies[5].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 6, 0, TimeSpan.Zero),
                    ["Kraków", "Katowice", "Gliwice"],
                    ["AWS", "Java"],
                    ["Remote", "Hybrid"],
                    ["Senior"],
                    ["B2B", "SpecificTaskContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("44c4509c-d56f-422c-b601-35d5c69283e7"),
                    "TypeScript Developer",
                    new Salary(15_000),
                    companies[6].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 7, 0, TimeSpan.Zero),
                    ["Białystok"],
                    ["TypeScript", "Python"],
                    ["Remote"],
                    ["Regular"],
                    ["EmploymentContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("6a37b912-d8f6-488c-aa6d-c1c7a5bd3026"),
                    "Senior JavaScript Developer",
                    new Salary(15_500, 17_500),
                    companies[0].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 8, 0, TimeSpan.Zero),
                    ["Warszawa", "Kraków"],
                    ["TypeScript", "SQL", "PHP"],
                    ["Remote"],
                    ["Senior"],
                    ["EmploymentContract", "B2B"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("923c67af-ec64-4d20-a0b7-ba423d2faee5"),
                    "Senior C# Developer",
                    new Salary(15_000, 19_000),
                    companies[1].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 9, 0, TimeSpan.Zero),
                    ["Zeilona Góra", "Gorzów Wielkopolski"],
                    ["C#", "Azure"],
                    ["Remote", "Hybrid", "OnSite"],
                    ["Senior"],
                    ["B2B", "MandateContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("9db0fdfd-d032-4b78-b850-75c7d90a8468"),
                    "Lead Python Developer",
                    new Salary(19_000, 24_000),
                    companies[2].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 10, 0, TimeSpan.Zero),
                    ["Bydgoszcz", "Toruń", "Szczecin"],
                    ["AWS", "Python"],
                    ["Remote"],
                    ["Lead"],
                    ["EmploymentContract", "B2B", "MandateContract", "SpecificTaskContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("34744eb2-da49-4314-a49d-a42b9f0efbea"),
                    "Junior C# Developer",
                    new Salary(10_000, 11_500),
                    companies[3].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 11, 0, TimeSpan.Zero),
                    ["Kielce", "Łódź"],
                    ["C#", "SQL"],
                    ["OnSite"],
                    ["Junior"],
                    ["Internship"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("f6f910b8-6667-425d-95e9-74810ff62b6e"),
                    "Fullstack Developer",
                    new Salary(14_000, 18_500),
                    companies[4].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 12, 0, TimeSpan.Zero),
                    ["Gorzów Wielkopolski", "Zielona Góra"],
                    ["AWS", "Azure", "TypeScript", "JavaScript", "Python", "SQL"],
                    ["Hybrid"],
                    ["Regular", "Senior", "Lead"],
                    ["EmploymentContract", "B2B"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("1a5a4855-247d-49c6-9b43-b488317881ca"),
                    "Senior Rust Developer",
                    new Salary(20_000, 25_000),
                    companies[5].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 13, 0, TimeSpan.Zero),
                    ["Wrocław"],
                    ["Rust", "C"],
                    ["Remote"],
                    ["Senior", "Lead"],
                    ["B2B"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("89ea7c6e-e49a-48d5-8439-03e21263b66e"),
                    "Mobile Developer",
                    new Salary(11_000, 17_000),
                    companies[6].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 14, 0, TimeSpan.Zero),
                    ["Rzeszów", "Lublin"],
                    ["Mobile"],
                    ["Remote", "Hybrid"],
                    ["Regular", "Senior"],
                    ["MandateContract", "SpecificTaskContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("ed31f986-09c2-4c9e-95ab-ea43e43e16e9"),
                    "Senior C/C++ Developer",
                    new Salary(16_000, 22_000),
                    companies[0].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 15, 0, TimeSpan.Zero),
                    ["Gdańsk", "Gdynia", "Sopot"],
                    ["C", "C++", "C#"],
                    ["Hybrid", "OnSite"],
                    ["Senior"],
                    ["EmploymentContract", "B2B"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("76dbce69-81ad-4ccb-befa-2707d94e25b5"),
                    "Junior JavaScript Developer",
                    new Salary(10_000),
                    companies[1].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 16, 0, TimeSpan.Zero),
                    ["Warszawa", "Kraków", "Wrocław", "Łódź", "Poznań", "Lublin"],
                    ["JavaScript"],
                    ["OnSite"],
                    ["Intern"],
                    ["SpecificTaskContract", "Internship"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                    ),
                CreateOffer(
                    new Identifier("0e278e45-3b6c-42b9-90ce-e902034cbf18"),
                    "Rust Developer",
                    new Salary(14_000, 19_000),
                    companies[2].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 17, 0, TimeSpan.Zero),
                    ["Warszawa", "Kraków"],
                    ["Rust", "SQL"],
                    ["Remote"],
                    ["Regular"],
                    ["EmploymentContract", "B2B"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("c74f934f-50e2-4655-9a37-2281cfddb043"),
                    "Senior Fullstack Developer",
                    new Salary(17_000, 22_000),
                    companies[3].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 18, 0, TimeSpan.Zero),
                    ["Katowice", "Gliwice"],
                    ["TypeScript", "Python", "SQL"],
                    ["Remote", "Hybrid"],
                    ["Regular", "Senior", "Lead"],
                    ["EmploymentContract", "B2B", "MandateContract", "SpecificTaskContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("7ee41092-960f-4b93-8a8d-27fb32e30855"),
                    "Junior C# Developer",
                    new Salary(7_000, 10_000),
                    companies[4].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 19, 0, TimeSpan.Zero),
                    ["Kraków", "Wrocław"],
                    ["Azure", "C#"],
                    ["Hybrid", "OnSite"],
                    ["Intern", "Junior"],
                    ["EmploymentContract", "B2B", "MandateContract", "Internship"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
                CreateOffer(
                    new Identifier("d36d28ac-1ec1-4e4a-bc31-1d353a3db78e"),
                    "Junior Python Developer",
                    new Salary(8_000, 11_000),
                    companies[5].Id,
                    new DateTimeOffset(2026, 03, 02, 18, 20, 0, TimeSpan.Zero),
                    ["Warszawa", "Gdańsk"],
                    ["SQL", "Python", "JavaScript"],
                    ["OnSite"],
                    ["Junior"],
                    ["EmploymentContract"],
                    locations, technologies, workModes, experienceLevels, employmentTypes
                ),
            };

            await dbContext.Offers.AddRangeAsync(offers);
            await dbContext.SaveChangesAsync();
        }
    }
    
    private async Task AddCompanies()
    {
        if (!dbContext.Companies.Any())
        {
            var companies = new List<Company>()
            {
                Company.Create(new Identifier("cfdc385e-6ce6-41df-9b9e-1538450c824c"), "Amazon"),
                Company.Create(new Identifier("c3fe179a-5e81-4e18-8c59-f53519187afa"), "Apple"),
                Company.Create(new Identifier("5c1f5397-93b9-4e8f-bc78-f5ce56de46ff"), "Google"),
                Company.Create(new Identifier("2febbdb9-5874-4968-bdd5-d7089fde7b13"), "Meta"),
                Company.Create(new Identifier("893ce20d-329c-4417-b68f-54a01572ab2d"), "Microsoft"),
                Company.Create(new Identifier("0cbde627-f281-49d4-8a89-5525a8776cf5"), "Netflix"),
                Company.Create(new Identifier("f371e4a6-016e-4d30-bbd9-08eef2e3dcc1"), "Oracle"),
            };
            await dbContext.Companies.AddRangeAsync(companies);
            await dbContext.SaveChangesAsync();
        }
    }

    private async Task AddLocations()
    {
        if (!dbContext.Locations.Any())
        {
            var locations = new List<Location>()
            {
                Location.Create(new Identifier("b912639e-5879-43c7-8123-877216cca43a"), "Białystok"),
                Location.Create(new Identifier("f318a9cf-ab02-448d-b5e1-15c9e36778a2"), "Bydgosz"),
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
                Location.Create(new Identifier("36cc43f3-ed29-4337-adaa-86c7d82e10be"), "Zielona Góra"),
            };

            await dbContext.Locations.AddRangeAsync(locations);
            await dbContext.SaveChangesAsync();
        }
    }

    private async Task AddTechnologies()
    {
        if (!dbContext.Technologies.Any())
        {
            var technologies = new List<Technology>()
            {
                Technology.Create(new Identifier("2557dbcc-8b98-44b1-a005-b63641fd21ee"), "AWS",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1hd3MiIHZpZXdCb3g9IjAgMCAzMiAxOCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KICAgIDxnCiAgICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMC42MDAyOTkwMDA3NDAwNTEzLCAwLCAwLCAwLjU2NDY2Njk4NjQ2NTQ1NDEsIC0wLjA3MzM5MjAwMzc3NDY0Mjk0LCAtMC4wMTAwNTAwMDA2MjI4Njg1MzgpIj4KICAgICAgICA8cGF0aAogICAgICAgICAgICBkPSJNMTUuMTQ0NiAxMS41OTQ5QzE1LjE0NDYgMTIuMjUxIDE1LjIxNTcgMTIuNzgyOSAxNS4zMzk3IDEzLjE3MjlDMTUuNDk3MiAxMy42MTE4IDE1LjY4NjggMTQuMDM4NCAxNS45MDY5IDE0LjQ0OTRDMTUuOTk1NiAxNC41OTEyIDE2LjAzMSAxNC43MzMgMTYuMDMxIDE0Ljg1NzJDMTYuMDMxIDE1LjAzNDQgMTUuOTI0NyAxNS4yMTE3IDE1LjY5NDIgMTUuMzg5MUwxNC41Nzc0IDE2LjEzMzdDMTQuNDE3OCAxNi4yNDAxIDE0LjI1ODIgMTYuMjkzMiAxNC4xMTYyIDE2LjI5MzJDMTMuOTM5IDE2LjI5MzIgMTMuNzYxNyAxNi4yMDQ2IDEzLjU4NDMgMTYuMDQ1QzEzLjM0NTIgMTUuNzg4NSAxMy4xMzE1IDE1LjUwOTQgMTIuOTQ2MiAxNS4yMTE3QzEyLjc2ODggMTQuOTEwNiAxMi41OTE1IDE0LjU3MzQgMTIuMzk2NiAxNC4xNjU4QzExLjAxMzUgMTUuNzk2NyA5LjI3NjAzIDE2LjYxMjMgNy4xODQxMSAxNi42MTI0QzUuNjk0OTYgMTYuNjEyNCA0LjUwNjk5IDE2LjE4NjggMy42MzgxOCAxNS4zMzZDMi43Njk1OCAxNC40ODQ3IDIuMzI2MzkgMTMuMzUwMSAyLjMyNjM5IDExLjkzMThDMi4zMjYzOSAxMC40MjQ5IDIuODU4MjUgOS4yMDE1OCAzLjkzOTc3IDguMjc5NjVDNS4wMjEwOCA3LjM1NzcxIDYuNDU3MzEgNi44OTY3NSA4LjI4MzQxIDYuODk2NzVDOC44ODYxOCA2Ljg5Njc1IDkuNTA2NzMgNi45NDk4NyAxMC4xNjI2IDcuMDM4NTVDMTAuODE4NyA3LjEyNzIzIDExLjQ5MjQgNy4yNjkwMyAxMi4yMDE2IDcuNDI4NjJWNi4xMzQzOUMxMi4yMDE2IDQuNzg2ODQgMTEuOTE3OCAzLjg0NzMzIDExLjM2ODIgMy4yOTc2OUMxMC44MDA5IDIuNzQ4MDQgOS44NDM0NiAyLjQ4MiA4LjQ3ODMzIDIuNDgyQzcuODU3NzggMi40ODIgNy4yMTk2NyAyLjU1MzExIDYuNTYzNTYgMi43MTI2OUM1LjkwNzQ2IDIuODcyMjggNS4yNjkzNCAzLjA2NzIgNC42NDg3OSAzLjMxNTQ3QzQuMzY1MTggMy40Mzk0OSA0LjE1MjQ4IDMuNTEwMzkgNC4wMjgyNCAzLjU0NTk1QzMuOTA0MDEgMy41ODE1IDMuODE1NTQgMy41OTkwNyAzLjc0NDYzIDMuNTk5MDdDMy40OTYzNyAzLjU5OTA3IDMuMzcyMzUgMy40MjE3MSAzLjM3MjM1IDMuMDQ5NDNWMi4xODA2MkMzLjM3MjM1IDEuODk3MDEgMy40MDc5IDEuNjg0MyAzLjQ5NjM3IDEuNTYwMjhDMy41ODUwNSAxLjQzNjA0IDMuNzQ0NjMgMS4zMTIwMSAzLjk5MjkgMS4xODc5OUM0LjYxMzM3IDAuODY4Njg1IDUuMzU3OTUgMC42MDI3MTUgNi4yMjY2MiAwLjM5MDA3OUM3LjA5NTY0IDAuMTU5NTk2IDguMDE3NTggMC4wNTMzNDczIDguOTkyNjMgMC4wNTMzNDczQzExLjEwMjUgMC4wNTMzNDczIDEyLjY0NSAwLjUzMTg4MyAxMy42Mzc5IDEuNDg5MzdDMTQuNjEyOSAyLjQ0NjY1IDE1LjEwOTQgMy45MDA0NiAxNS4xMDk0IDUuODUwNzlWMTEuNTk0OUgxNS4xNDQ2Wk03Ljk0NjQ2IDE0LjI4OThDOC41MzE2NyAxNC4yODk4IDkuMTM0NDQgMTQuMTgzNSA5Ljc3MjU2IDEzLjk3MDZDMTAuNDEwOSAxMy43NTc5IDEwLjk3ODMgMTMuMzY3OSAxMS40NTY4IDEyLjgzNkMxMS43NDA3IDEyLjQ5OTMgMTEuOTUzNCAxMi4xMjcgMTIuMDU5NiAxMS43MDEzQzEyLjE2NjEgMTEuMjc1OSAxMi4yMzcgMTAuNzYxNiAxMi4yMzcgMTAuMTU4OVY5LjQxNDI5QzExLjY5OTMgOS4yODM1MSAxMS4xNTQ3IDkuMTgyODkgMTAuNjA1OCA5LjExMjlDMTAuMDUzMSA5LjA0Mjc3IDkuNDk2NDggOS4wMDcyMSA4LjkzOTMgOS4wMDY0NUM3Ljc1MTMzIDkuMDA2NDUgNi44ODI3MyA5LjIzNjkzIDYuMjk3NzMgOS43MTU2N0M1LjcxMjc0IDEwLjE5NDQgNS40Mjg5MiAxMC44NjgxIDUuNDI4OTIgMTEuNzU0NUM1LjQyODkyIDEyLjU4NzcgNS42NDE2MyAxMy4yMDgzIDYuMDg0ODIgMTMuNjMzOUM2LjUxMDQ0IDE0LjA3NzEgNy4xMzA5OSAxNC4yODk4IDcuOTQ2NDYgMTQuMjg5OFpNMjIuMTgzMSAxNi4yMDQ2QzIxLjg2NCAxNi4yMDQ2IDIxLjY1MTIgMTYuMTUxNCAyMS41MDk0IDE2LjAyNzJDMjEuMzY3NiAxNS45MjEgMjEuMjQzNCAxNS42NzI3IDIxLjEzNzIgMTUuMzM2TDE2Ljk3MDkgMS42MzExOEMxNi44NjQyIDEuMjc2NDYgMTYuODExMSAxLjA0NTk3IDE2LjgxMTEgMC45MjE5NDlDMTYuODExMSAwLjYzODM0MSAxNi45NTI5IDAuNDc4NTUgMTcuMjM2NyAwLjQ3ODU1SDE4Ljk3NDFDMTkuMzEwOSAwLjQ3ODU1IDE5LjU0MTUgMC41MzE4ODMgMTkuNjY1NiAwLjY1NTkwOUMxOS44MDc0IDAuNzYyMzY3IDE5LjkxMzggMS4wMTA2MyAyMC4wMjAxIDEuMzQ3MzZMMjIuOTk4NiAxMy4wODQyTDI1Ljc2NDQgMS4zNDczNkMyNS44NTMxIDAuOTkyODUxIDI1Ljk1OTUgMC43NjIzNjcgMjYuMTAxMSAwLjY1NTkwOUMyNi4yNDMxIDAuNTQ5NjYxIDI2LjQ5MTQgMC40Nzg3NTkgMjYuODEwNiAwLjQ3ODc1OUgyOC4yMjg4QzI4LjU2NTYgMC40Nzg3NTkgMjguNzk2MiAwLjUzMTg4MyAyOC45Mzc4IDAuNjU1OTA5QzI5LjA3OTkgMC43NjIzNjcgMjkuMjAzOSAxLjAxMDYzIDI5LjI3NDggMS4zNDczNkwzMi4wNzYxIDEzLjIyNjFMMzUuMTQzMSAxLjM0NzM2QzM1LjI0OTQgMC45OTI4NTEgMzUuMzczNiAwLjc2MjM2NyAzNS40OTc2IDAuNjU1OTA5QzM1LjYzOTQgMC41NDk2NjEgMzUuODY5OSAwLjQ3ODc1OSAzNi4xODkxIDAuNDc4NzU5SDM3LjgzNzhDMzguMTIxNiAwLjQ3ODc1OSAzOC4yODEyIDAuNjIwNTYzIDM4LjI4MTIgMC45MjE5NDlDMzguMjgxMiAxLjAxMDYzIDM4LjI2MzQgMS4wOTkzMSAzOC4yNDU3IDEuMjA1NTZDMzguMjI3OSAxLjMxMTggMzguMTkyNSAxLjQ1MzgyIDM4LjEyMTYgMS42NDg5NkwzMy44NDg3IDE1LjM1MzVDMzMuNzQyNCAxNS43MDgyIDMzLjYxODMgMTUuOTM4NyAzMy40NzY0IDE2LjA0NUMzMy4zMzQ2IDE2LjE1MTQgMzMuMTA0MSAxNi4yMjIzIDMyLjgwMjkgMTYuMjIyM0gzMS4yNzgyQzMwLjk0MTMgMTYuMjIyMyAzMC43MTA4IDE2LjE2OTIgMzAuNTY4OCAxNi4wNDVDMzAuNDI3IDE1LjkyMSAzMC4zMDMgMTUuNjkwNSAzMC4yMzIxIDE1LjMzNkwyNy40ODM4IDMuOTAwNDZMMjQuNzUzNiAxNS4zMThDMjQuNjY1MSAxNS42NzI3IDI0LjU1ODYgMTUuOTAzMiAyNC40MTY4IDE2LjAyNzJDMjQuMjc1IDE2LjE1MTQgMjQuMDI2OCAxNi4yMDQ2IDIzLjcwNzggMTYuMjA0NkgyMi4xODMxWk00NC45NjUyIDE2LjY4MzNDNDQuMDQzMyAxNi42ODMzIDQzLjEyMTQgMTYuNTc2OSA0Mi4yMzUgMTYuMzY0MUM0MS4zNDg0IDE2LjE1MTQgNDAuNjU3MiAxNS45MjA3IDQwLjE5NjIgMTUuNjU1MUMzOS45MTI0IDE1LjQ5NTMgMzkuNzE3MiAxNS4zMTgyIDM5LjY0NjUgMTUuMTU4NkMzOS41Nzc2IDE1LjAwMjEgMzkuNTQxNCAxNC44MzMxIDM5LjU0MDEgMTQuNjYyMVYxMy43NTc5QzM5LjU0MDEgMTMuMzg1NiAzOS42ODE5IDEzLjIwODMgMzkuOTQ3OSAxMy4yMDgzQzQwLjA1NjUgMTMuMjA4NyA0MC4xNjQzIDEzLjIyNjcgNDAuMjY3MSAxMy4yNjE2QzQwLjM3MzMgMTMuMjk3MiA0MC41MzI5IDEzLjM2NzkgNDAuNzEwMyAxMy40Mzg4QzQxLjMzNjQgMTMuNzE0NCA0MS45OTAxIDEzLjkyMjQgNDIuNjYwNCAxNC4wNTkzQzQzLjM1NDkgMTQuMjAwMSA0NC4wNjE3IDE0LjI3MTQgNDQuNzcwMyAxNC4yNzJDNDUuODg3MiAxNC4yNzIgNDYuNzU2IDE0LjA3NzEgNDcuMzU4OCAxMy42ODdDNDcuOTYxNSAxMy4yOTcgNDguMjgwNyAxMi43Mjk3IDQ4LjI4MDcgMTIuMDAyN0M0OC4yODA3IDExLjUwNjQgNDguMTIxMSAxMS4wOTg2IDQ3LjgwMTkgMTAuNzYxNkM0Ny40ODI4IDEwLjQyNDcgNDYuODggMTAuMTIzNSA0Ni4wMTE0IDkuODM5N0w0My40NDA1IDkuMDQyQzQyLjE0NjMgOC42MzQxNiA0MS4xODkgOC4wMzEzOSA0MC42MDM4IDcuMjMzNDhDNDAuMDE4OCA2LjQ1MzM1IDM5LjcxNzQgNS41ODQ3NSAzOS43MTc0IDQuNjYyODFDMzkuNzE3NCAzLjkxODI0IDM5Ljg3NyAzLjI2MjIgNDAuMTk2MiAyLjY5NDcxQzQwLjUxNTEgMi4xMjc0OSA0MC45NDA4IDEuNjMxMTggNDEuNDcyNiAxLjI0MTExQzQyLjAwNDUgMC44MzMyNjkgNDIuNjA3MyAwLjUzMTg4MyA0My4zMTY1IDAuMzE5MTc3QzQ0LjAyNTUgMC4xMDY0NzEgNDQuNzcwMSAwLjAxNzc5MTcgNDUuNTUwMiAwLjAxNzc5MTdDNDUuOTQwMyAwLjAxNzc5MTcgNDYuMzQ4MSAwLjAzNTU2OTUgNDYuNzM4MiAwLjA4ODY5MzdDNDcuMTQ2IDAuMTQxODE4IDQ3LjUxODMgMC4yMTI3MiA0Ny44OTA2IDAuMjgzNjIyQzQ4LjI0NTEgMC4zNzIzMDIgNDguNTgyMSAwLjQ2MDk4MSA0OC45MDEyIDAuNTY3NDM5QzQ5LjIyMDMgMC42NzM2ODcgNDkuNDY4NSAwLjc4MDAwNSA0OS42NDU4IDAuODg2MzkzQzQ5Ljg5NDEgMS4wMjg0MSA1MC4wNzEyIDEuMTcwMjEgNTAuMTc3NyAxLjMyOTc5QzUwLjI4NDEgMS40NzE2IDUwLjMzNzMgMS42NjY1OSA1MC4zMzczIDEuOTE0NzlWMi43NDgwNEM1MC4zMzczIDMuMTIwMzMgNTAuMTk1NSAzLjMxNTQ3IDQ5LjkyOTQgMy4zMTU0N0M0OS43ODc2IDMuMzE1NDcgNDkuNTU3MSAzLjI0NDM1IDQ5LjI1NiAzLjEwMjU1QzQ4LjI0NTEgMi42NDE1OCA0Ny4xMTA0IDIuNDExMSA0NS44NTE4IDIuNDExMUM0NC44NDEyIDIuNDExMSA0NC4wNDMzIDIuNTcwNjggNDMuNDkzNyAyLjkwNzYyQzQyLjk0NDIgMy4yNDQzNSA0Mi42NjA0IDMuNzU4NjUgNDIuNjYwNCA0LjQ4NTQ1QzQyLjY2MDQgNC45ODE5NyA0Mi44Mzc4IDUuNDA3MzkgNDMuMTkyMyA1Ljc0NDMzQzQzLjU0NjggNi4wODEyNyA0NC4yMDI5IDYuNDE4IDQ1LjE0MjYgNi43MTkzOUw0Ny42NjAxIDcuNTE3M0M0OC45MzY2IDcuOTI1MTQgNDkuODU4NSA4LjQ5MjM1IDUwLjQwODIgOS4yMTkxNUM1MC45NTc4IDkuOTQ1OTUgNTEuMjIzOSAxMC43Nzk0IDUxLjIyMzkgMTEuNzAxM0M1MS4yMjM5IDEyLjQ2MzcgNTEuMDY0MSAxMy4xNTUyIDUwLjc2MjcgMTMuNzU3OUM1MC40NDM3IDE0LjM2MDcgNTAuMDE4MSAxNC44OTI2IDQ5LjQ2ODUgMTUuMzE4MkM0OC45MTg4IDE1Ljc2MTQgNDguMjYyOSAxNi4wODA1IDQ3LjUwMDYgMTYuMzExQzQ2LjcwMjYgMTYuNTU5MyA0NS44Njk0IDE2LjY4MzMgNDQuOTY1MiAxNi42ODMzWiIKICAgICAgICAgICAgZmlsbD0iIzI1MkYzRSIgc3R5bGU9InN0cm9rZS13aWR0aDogMHB4OyIgLz4KICAgICAgICA8cGF0aAogICAgICAgICAgICBkPSJNNDguMzE2IDI1LjI5OTdDNDIuNDgzMiAyOS42MDggMzQuMDA4NCAzMS44OTUgMjYuNzIxOSAzMS44OTVDMTYuNTA5NyAzMS44OTUgNy4zMDgzMiAyOC4xMTg2IDAuMzU4NDYyIDIxLjg0MjRDLTAuMTkxMTg1IDIxLjM0NjEgMC4zMDUxMjkgMjAuNjcyNCAwLjk2MTAyNCAyMS4wNjIzQzguNDc4MzEgMjUuNDIzOSAxNy43NTA4IDI4LjA2NTUgMjcuMzQyNCAyOC4wNjU1QzMzLjgxMzUgMjguMDY1NSA0MC45MjMgMjYuNzE4MSA0Ny40NjUyIDIzLjk1MjNDNDguNDQwMiAyMy41MDg5IDQ5LjI3MzUgMjQuNTkwNyA0OC4zMTYgMjUuMjk5N1pNNTAuNzQ1MSAyMi41MzM5QzUwLjAwMDUgMjEuNTc2NiA0NS44MTYyIDIyLjA3MjkgNDMuOTE5MiAyMi4zMDM0QzQzLjM1MTggMjIuMzc0NSA0My4yNjMxIDIxLjg3OCA0My43Nzc0IDIxLjUwNTdDNDcuMTEwNSAxOS4xNjUzIDUyLjU4ODkgMTkuODM5MiA1My4yMjcxIDIwLjYxOTFDNTMuODY1NCAyMS40MTcgNTMuMDQ5NyAyNi44OTUzIDQ5LjkyOTQgMjkuNTE5M0M0OS40NTA5IDI5LjkyNzEgNDguOTg5OSAyOS43MTQ0IDQ5LjIwMjYgMjkuMTgyNkM0OS45MTE2IDI3LjQyNzIgNTEuNDg5NiAyMy40NzM2IDUwLjc0NTEgMjIuNTMzOVoiCiAgICAgICAgICAgIGZpbGw9IiNGRjk5MDAiIHN0eWxlPSJzdHJva2Utd2lkdGg6IDBweDsiIC8+CiAgICA8L2c+Cjwvc3ZnPg==")),
                Technology.Create(new Identifier("91d3363e-538b-43eb-8d24-65011950b2fd"), "Azure",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1henVyZSIgdmlld0JveD0iMCAwIDMyIDMyIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciPgogICAgPHBhdGggZmlsbD0iIzAxNTc5YiIKICAgICAgICBkPSJNMTIuMDAxIDRoNy4xMDJsLTcuMzcyIDIzLjE4MWExLjE0IDEuMTQgMCAwIDEtMS4wNzMuODE5SDUuMTNBMS4xNjYgMS4xNjYgMCAwIDEgNCAyNi44MDFhMS4zIDEuMyAwIDAgMSAuMDYtLjM4NWw2Ljg3LTIxLjU5OUExLjE0IDEuMTQgMCAwIDEgMTIuMDAxIDQiIC8+CiAgICA8cGF0aCBmaWxsPSIjMTk3NmQyIgogICAgICAgIGQ9Ik0yMi4zMiAyMEgxMS4wNmEuNTM3LjUzNyAwIDAgMC0uNTIyLjU1YS41Ny41NyAwIDAgMCAuMTY2LjQwOGw3LjIzNiA2LjcxNmExLjEgMS4xIDAgMCAwIC43NzUuMzI1aDYuMzc2WiIgLz4KICAgIDxwYXRoIGZpbGw9IiMyOWI2ZjYiCiAgICAgICAgZD0iTTIxLjA3MSA0LjgxNkExLjE0IDEuMTQgMCAwIDAgMjAuMDAxIDRoLTcuOTE1YTEuMTQgMS4xNCAwIDAgMSAxLjA3Mi44MTVsNi44NjggMjEuNTk5YTEuMjIgMS4yMiAwIDAgMS0uNzEgMS41MmExLjEgMS4xIDAgMCAxLS4zNjIuMDY0aDcuOTE1QTEuMTY2IDEuMTY2IDAgMCAwIDI4IDI2LjhhMS4zIDEuMyAwIDAgMC0uMDYtLjM4NUwyMS4wNzIgNC44MTdaIiAvPgo8L3N2Zz4=")),
                Technology.Create(new Identifier("916e66a0-e1da-4db9-b8ea-9316a9240746"), "C",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1jIiB2aWV3Qm94PSIwIDAgMzIgMzIiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiAgICA8ZyBmaWxsLXJ1bGU9ImV2ZW5vZGQiCiAgICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMS43MTkyNjc5NjQzNjMwOTg0LCAwLCAwLCAxLjc3Nzc3NzkxMDIzMjU0NDIsIC0zLjQwMzY1OTEwNTMwMDg4OSwgLTUuODAwODg5MDE1MTk3NzU0KSI+CiAgICAgICAgPHBhdGgKICAgICAgICAgICAgZD0iTTEwLjgxNiAzLjM4NmMuMjkxLS4xNjMuNjQ5LS4xNjMuOTQgMGw3LjIwMyA0LjA0M2EuOTEuOTEgMCAwIDEgLjQ3Ljc5MXY4LjA4NmEuOTEuOTEgMCAwIDEtLjQ3Ljc5MmwtNy4yMDMgNC4wNDNjLS4yOTEuMTYzLS42NDkuMTYzLS45NCAwbC03LjIwMy00LjA0M2EuOTEuOTEgMCAwIDEtLjQ3LS43OTFWOC4yMjFhLjkxLjkxIDAgMCAxIC40Ny0uNzkybDcuMjAzLTQuMDQzeiIKICAgICAgICAgICAgZmlsbD0iIzAwNDQ4MiIgc3R5bGU9InN0cm9rZS13aWR0aDogMHB4OyIgLz4KICAgICAgICA8cGF0aAogICAgICAgICAgICBkPSJNMy4yNzMgMTYuNzIyYy0uMTE0LS4xNTMtLjEzLS4yOTctLjEzLS40OTJWOC4xOWMwLS4zMjUuMTc5LS42MjUuNDY5LS43ODdsNy4xNzgtNC4wMmMuMjktLjE2Mi42ODMtLjE1OS45NzMuMDAzbDcuMTYzIDMuOTk5Yy4xMTYuMDY1LjIwNC4xNDQuMjgzLjI0N2wtMTUuOTM1IDkuMDl6IgogICAgICAgICAgICBmaWxsPSIjNjU5YWQyIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IiAvPgogICAgICAgIDxwYXRoCiAgICAgICAgICAgIGQ9Ik0xMS4yODYgNi4yNjNjMy4zMTIgMCA2IDIuNjg4IDYgNnMtMi42ODggNi02IDYtNi0yLjY4OC02LTYgMi42ODgtNiA2LTZ6bTAgM2EzIDMgMCAwIDEgMyAzYzAgMS42NTYtMS4zNDQgMy0zIDNzLTMtMS4zNDQtMy0zYTMgMyAwIDAgMSAzLTN6IgogICAgICAgICAgICBmaWxsPSIjZmZmIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IiAvPgogICAgICAgIDxwYXRoCiAgICAgICAgICAgIGQ9Ik0xOS4yMDggNy42MzdjLjIyMS4yMDcuMjE3LjUxOS4yMTcuNzY1bC4wMDQgNy44NzlhLjkzLjkzIDAgMCAxLS4xMzkuNDgzbC04LjE3OS00LjUgOC4wOTYtNC42MjZ6IgogICAgICAgICAgICBmaWxsPSIjMDA1OTljIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IiAvPgogICAgPC9nPgo8L3N2Zz4=")),
                Technology.Create(new Identifier("ab806f7c-4645-469e-a423-0107e9e175ff"), "C++",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1jcHAiIHZpZXdCb3g9IjAgMCAzMiAzMiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KICAgIDxwYXRoCiAgICAgICAgZD0iTSAzMC44NTYgOS40MDkgQyAzMC44NjcgOC45MTEgMzAuNzQxIDguNDIgMzAuNDkzIDcuOTg4IEMgMzAuMjMyIDcuNTY0IDI5Ljg2MyA3LjIxNyAyOS40MjMgNi45ODMgQyAyNS40NjYgNC43OTggMjEuNTA4IDIuNjE1IDE3LjU0NyAwLjQzMiBDIDE3LjA3IDAuMTQ0IDE2LjUyMiAtMC4wMDUgMTUuOTY0IDAgQyAxNS40MDcgMC4wMDUgMTQuODYyIDAuMTY0IDE0LjM5IDAuNDU5IEMgMTIuODE1IDEuMzUgNC45MzMgNS42NzYgMi41ODQgNi45OCBDIDIuMTM3IDcuMjA1IDEuNzY0IDcuNTUzIDEuNTA5IDcuOTgzIEMgMS4yNTQgOC40MTQgMS4xMjggOC45MDggMS4xNDUgOS40MDggTCAxLjE0NSAyMi41OTQgQyAxLjEzNCAyMy4wODEgMS4yNTIgMjMuNTYyIDEuNDg4IDIzLjk4OCBDIDEuNzUgMjQuNDI1IDIuMTI3IDI0Ljc4MSAyLjU3OCAyNS4wMTcgQyA0LjkyOCAyNi4zMjEgMTIuODEgMzAuNjQ3IDE0LjM4NSAzMS41MzcgQyAxNC44NTcgMzEuODMzIDE1LjQwMiAzMS45OTMgMTUuOTU5IDMxLjk5OCBDIDE2LjUxNyAzMi4wMDQgMTcuMDY1IDMxLjg1NCAxNy41NDIgMzEuNTY3IEMgMjEuNDk2IDI5LjM4IDI1LjQ1MiAyNy4xOTYgMjkuNDExIDI1LjAxNiBDIDI5Ljg2MiAyNC43NzkgMzAuMjM5IDI0LjQyMyAzMC41MDIgMjMuOTg3IEMgMzAuNzM4IDIzLjU2MSAzMC44NTcgMjMuMDggMzAuODQ1IDIyLjU5MyBMIDMwLjg0NSA5LjQwOSIKICAgICAgICBmaWxsPSIjNjU5QUQyIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNiwgNC40NDA4OTIwOTg1MDA2MjZlLTE2KSIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTSAzMC4zNDEgMjQuMTk1IEMgMzAuNDAxIDI0LjEyOSAzMC40NTcgMjQuMDYgMzAuNTA5IDIzLjk4NyBDIDMwLjc0NSAyMy41NjEgMzAuODYzIDIzLjA4IDMwLjg1MiAyMi41OTMgTCAzMC44NTIgOS40MDkgQyAzMC44NjIgOC45MTEgMzAuNzM2IDguNDIgMzAuNDg4IDcuOTg4IEMgMzAuNDQ3IDcuOTIgMzAuMzg3IDcuODY4IDMwLjM0IDcuODA1IEwgMTYuMDAxIDE2LjAwMSBMIDMwLjM0MSAyNC4xOTUgWiIKICAgICAgICBmaWxsPSIjMDA1OTlDIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNiwgNC40NDA4OTIwOTg1MDA2MjZlLTE2KSIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTSAzMC4zNDEgMjQuMTk1IEwgMTYuMDAxIDE2LjAwMSBMIDEuNjYxIDI0LjE5NSBDIDEuOTAyIDI0LjUzNiAyLjIxOCAyNC44MTggMi41ODUgMjUuMDE4IEMgNC45MzUgMjYuMzIyIDEyLjgxNyAzMC42NDggMTQuMzkyIDMxLjUzOSBDIDE0Ljg2NCAzMS44MzUgMTUuNDA5IDMxLjk5NCAxNS45NjYgMzEuOTk5IEMgMTYuNTI0IDMyLjAwNSAxNy4wNzIgMzEuODU1IDE3LjU0OSAzMS41NjggQyAyMS41MDMgMjkuMzgxIDI1LjQ1OSAyNy4xOTcgMjkuNDE4IDI1LjAxNyBDIDI5Ljc4NCAyNC44MTcgMzAuMSAyNC41MzYgMzAuMzQxIDI0LjE5NSBaIgogICAgICAgIGZpbGw9IiMwMDQ0ODIiIHN0eWxlPSJzdHJva2Utd2lkdGg6IDBweDsiCiAgICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMSwgMCwgMCwgMSwgNC40NDA4OTIwOTg1MDA2MjZlLTE2LCA0LjQ0MDg5MjA5ODUwMDYyNmUtMTYpIiAvPgogICAgPHBhdGgKICAgICAgICBkPSJNIDIwLjExNSAxOC4zMDkgQyAxOS42MDYgMTkuMjE0IDE4LjgxMiAxOS45MjYgMTcuODU2IDIwLjMzMyBDIDE2LjkwMSAyMC43NCAxNS44MzggMjAuODIgMTQuODMyIDIwLjU2IEMgMTMuODI2IDIwLjMwMSAxMi45MzUgMTkuNzE2IDEyLjI5NiAxOC44OTcgQyAxMS42NTggMTguMDc4IDExLjMwOCAxNy4wNzEgMTEuMzAxIDE2LjAzMiBDIDExLjI5NCAxNC45OTMgMTEuNjMxIDEzLjk4MiAxMi4yNTggMTMuMTU0IEMgMTIuODg2IDEyLjMyNyAxMy43NyAxMS43MyAxNC43NzIgMTEuNDU3IEMgMTUuNzc0IDExLjE4NCAxNi44MzggMTEuMjUgMTcuNzk5IDExLjY0NSBDIDE4Ljc2IDEyLjAzOSAxOS41NjMgMTIuNzQgMjAuMDg0IDEzLjYzOSBMIDI0LjIxNSAxMS4yNyBDIDIzLjE2NiA5LjQ3IDIxLjU1NSA4LjA2NSAxOS42MyA3LjI3MiBDIDE3LjcwNCA2LjQ3OCAxNS41NzEgNi4zMzkgMTMuNTU5IDYuODc3IEMgMTEuNTQ3IDcuNDE1IDkuNzY4IDguNTk5IDguNDk1IDEwLjI0OCBDIDcuMjIyIDExLjg5NyA2LjUyNyAxMy45MTggNi41MTYgMTYuMDAxIEMgNi41MTMgMTcuNjUyIDYuOTQ3IDE5LjI3NSA3Ljc3MyAyMC43MDUgQyA4LjYwOSAyMi4xNSA5LjgxMSAyMy4zNDkgMTEuMjU3IDI0LjE4MiBDIDEyLjcwMyAyNS4wMTUgMTQuMzQ0IDI1LjQ1MyAxNi4wMTMgMjUuNDUxIEMgMTcuNjgyIDI1LjQ0OSAxOS4zMjEgMjUuMDA4IDIwLjc2NSAyNC4xNzEgQyAyMi4yMSAyMy4zMzUgMjMuNDA5IDIyLjEzMyAyNC4yNDEgMjAuNjg2IEwgMjAuMTE1IDE4LjMwOSBaIgogICAgICAgIGZpbGw9IndoaXRlIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNiwgNC40NDA4OTIwOTg1MDA2MjZlLTE2KSIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTSAyNS4yMyAxNS40NzMgTCAyNC4xNzEgMTUuNDczIEwgMjQuMTcxIDE0LjQyIEwgMjMuMTE0IDE0LjQyIEwgMjMuMTE0IDE1LjQ3MyBMIDIyLjA1NiAxNS40NzMgTCAyMi4wNTYgMTYuNTI4IEwgMjMuMTE0IDE2LjUyOCBMIDIzLjExNCAxNy41NzkgTCAyNC4xNzEgMTcuNTc5IEwgMjQuMTcxIDE2LjUyOCBMIDI1LjIzIDE2LjUyOCBMIDI1LjIzIDE1LjQ3MyBaIE0gMjkuMTk4IDE1LjQ3MyBMIDI4LjE0IDE1LjQ3MyBMIDI4LjE0IDE0LjQyIEwgMjcuMDgyIDE0LjQyIEwgMjcuMDgyIDE1LjQ3MyBMIDI2LjAyNCAxNS40NzMgTCAyNi4wMjQgMTYuNTI4IEwgMjcuMDgyIDE2LjUyOCBMIDI3LjA4MiAxNy41NzkgTCAyOC4xNCAxNy41NzkgTCAyOC4xNCAxNi41MjggTCAyOS4xOTggMTYuNTI4IEwgMjkuMTk4IDE1LjQ3MyBaIgogICAgICAgIGZpbGw9IndoaXRlIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNiwgNC40NDA4OTIwOTg1MDA2MjZlLTE2KSIgLz4KPC9zdmc+")),
                Technology.Create(new Identifier("2b43d6e4-482b-46fc-ac33-ca7366f16af2"), "C#",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1jc2hhcnAiIHZpZXdCb3g9IjAgMCAzMiAzMiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KICAgIDxwYXRoCiAgICAgICAgZD0iTTI4Ljg1IDcuNjc0OTlMMTYuNzc1IDAuNzI0OTg4QzE2LjU3NSAwLjU5OTk4OCAxNi4zIDAuNTQ5OTg4IDE2IDAuNTQ5OTg4QzE1LjcgMC41NDk5ODggMTUuNDI1IDAuNjI0OTg4IDE1LjIyNSAwLjcyNDk4OEwzLjIyNSA3LjY5OTk5QzIuOCA3Ljk0OTk5IDIuNSA4LjU3NDk5IDIuNSA5LjA0OTk5VjIyLjk3NUMyLjUgMjMuMjUgMi41NSAyMy41NzUgMi43NSAyMy44NUwyOS40NSA4LjM0OTk5QzI5LjMgOC4wNDk5OSAyOS4wNzUgNy44MjQ5OSAyOC44NSA3LjY3NDk5WiIKICAgICAgICBmaWxsPSIjOUI0Rjk2IiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNiwgNC40NDA4OTIwOTg1MDA2MjZlLTE2KSIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTTIuNjc0OTkgMjMuODI1QzIuNzk5OTkgMjQuMDI1IDIuOTc0OTkgMjQuMiAzLjE0OTk5IDI0LjNMMTUuMiAzMS4yNzVDMTUuNCAzMS40IDE1LjY3NSAzMS40NSAxNS45NzUgMzEuNDVDMTYuMjc1IDMxLjQ1IDE2LjU1IDMxLjM3NSAxNi43NSAzMS4yNzVMMjguNzUgMjQuM0MyOS4xNzUgMjQuMDUgMjkuNDc1IDIzLjQyNSAyOS40NzUgMjIuOTVWOS4wMjUwMUMyOS40NzUgOC44MDAwMSAyOS40NSA4LjU1MDAxIDI5LjMyNSA4LjMyNTAxTDIuNjc0OTkgMjMuODI1WiIKICAgICAgICBmaWxsPSIjNjgyMTdBIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNiwgNC40NDA4OTIwOTg1MDA2MjZlLTE2KSIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTTIxLjMyNSAxOS4wMjVDMjAuMjc1IDIwLjg3NSAxOC4yNzUgMjIuMTI1IDE2IDIyLjEyNUMxMi42MjUgMjIuMTI1IDkuODc1IDE5LjM3NSA5Ljg3NSAxNkM5Ljg3NSAxMi42MjUgMTIuNjI1IDkuODc1IDE2IDkuODc1QzE4LjI3NSA5Ljg3NSAyMC4yNzUgMTEuMTI1IDIxLjMyNSAxM0wyNC41NzUgMTEuMTI1QzIyLjg3NSA4LjE1IDE5LjY3NSA2LjEyNSAxNiA2LjEyNUMxMC41NSA2LjEyNSA2LjEyNSAxMC41NSA2LjEyNSAxNkM2LjEyNSAyMS40NSAxMC41NSAyNS44NzUgMTYgMjUuODc1QzE5LjY1IDI1Ljg3NSAyMi44NSAyMy44NzUgMjQuNTUgMjAuOTI1TDIxLjMyNSAxOS4wMjVaTTI0LjI1IDE2LjU1TDI0LjQ3NSAxNS40NzVIMjMuNDI1VjE0LjNIMjQuN0wyNSAxMi43NUgyNi4yMjVMMjUuOTI1IDE0LjI3NUgyNi44NzVMMjcuMTc1IDEyLjc1SDI4LjM3NUwyOC4wNzUgMTQuMjc1SDI4LjY3NVYxNS40NUgyNy44NUwyNy42MjUgMTYuNTI1SDI4LjY3NVYxNy43SDI3LjRMMjcuMSAxOS4ySDI1Ljg3NUwyNi4xNzUgMTcuN0gyNS4yMjVMMjQuOTI1IDE5LjJIMjMuNzI1TDI0LjAyNSAxNy43SDIzLjQyNVYxNi41MjVIMjQuMjVWMTYuNTVaTTI1LjQ1IDE2LjU1SDI2LjRMMjYuNjI1IDE1LjQ3NUgyNS42NzVMMjUuNDUgMTYuNTVaIgogICAgICAgIGZpbGw9IndoaXRlIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNiwgNC40NDA4OTIwOTg1MDA2MjZlLTE2KSIgLz4KPC9zdmc+")),
                Technology.Create(new Identifier("ad4e8ed7-20cd-4b4f-8503-4cf3ed161256"), "Go",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1nbyIgdmlld0JveD0iMCAwIDMyIDMyIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciPgogICAgPGcKICAgICAgICB0cmFuc2Zvcm09Im1hdHJpeCgxLjMzMTc1MDk4ODk2MDI2NjEsIDAsIDAsIDEuMzMxNzUwOTg4OTYwMjY2MSwgMTUuOTgxMDExMzkwNjg2MDM1LCAxNS43ODcwOTMxNjI1MzY2MjMpIj4KICAgICAgICA8ZyBzdHlsZT0iIj4KICAgICAgICAgICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSAwIDAgMSAyLjI5IDAuMTYpIj4KICAgICAgICAgICAgICAgIDxwYXRoCiAgICAgICAgICAgICAgICAgICAgc3R5bGU9InN0cm9rZTogbm9uZTsgc3Ryb2tlLWRhc2hhcnJheTogbm9uZTsgc3Ryb2tlLWxpbmVjYXA6IGJ1dHQ7IHN0cm9rZS1kYXNob2Zmc2V0OiAwOyBzdHJva2UtbGluZWpvaW46IG1pdGVyOyBzdHJva2UtbWl0ZXJsaW1pdDogNDsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyBzdHJva2Utd2lkdGg6IDA7IGZpbGw6IHJnYigwLCAxNzQsIDIxNyk7IgogICAgICAgICAgICAgICAgICAgIHRyYW5zZm9ybT0iIHRyYW5zbGF0ZSgtMTQuMjksIC0xMi4xNikiCiAgICAgICAgICAgICAgICAgICAgZD0iTSAyMi43MyA4LjYxIEMgMjEuODMzNzE0MzMyNzI2MTkgNy41NzY3OTEyNzgwMzI1MzQgMjAuNTQ3MDcyNzAyNzI4OTA4IDYuOTY0Mjc3Mzc1MzAxNDMzNSAxOS4xOCA2LjkxOTk5OTk5OTk5OTk5OSBDIDE2LjU2ODA0Njc4NjYyNzIyIDYuODc3NTE1OTY0OTgwOTc0IDE0LjI2OTk2OTI5NDcxNzAxIDguNjM3MzA1MDM1MzYyNjY1IDEzLjYyOTk5OTk5OTk5OTk5OSAxMS4xNjk5OTk5OTk5OTk5OTggTCAxMCAxMS4xNyBMIDkgMTMuMTcgTCAxMi44MyAxMy4xNyBDIDEyLjI5MTg0MjcyNjM3ODkxNSAxNC41NTQyNTU3OTkxNjczNCAxMC45NDQ4MDU1NTU0NjgxMjIgMTUuNDUzNjEyOTYwNzU0NjY1IDkuNDYgMTUuNDIgQyA4LjY0NDY4NDc2NDMzODEwOSAxNS4zOTczODAzNTY1ODc3ODkgNy44NzU5OTAyNTMyNjk2MzYgMTUuMDM0Nzg4NjA2MDgzNzk0IDcuMzQgMTQuNDIgQyA2Ljc1MjM4MTI2MjQ3MzU4NiAxMy43MzUyMjg2OTIxMTE4NjIgNi40NzY5NDI5NTgwNDUxNzIgMTIuODM2NDMwMDE0NTAzMzU5IDYuNTggMTEuOTQwMDAwMDAwMDAwMDAxIEMgNi43NDA4MDQxMjE4ODU4OSAxMC4wNDgyNTY4MDEzMTgzNzIgOC4zMjE0Mzc5OTgxNzI1MTEgOC41OTM1NTI1NDcwNDM1OTUgMTAuMjE5OTk5OTk5OTk5OTk3IDguNTkgQyAxMS4xNDExNzU5NzU4ODA0MTkgOC42Mjk1NDg0MzUwMDUxNyAxMS45OTMwMDA5MTY4OTA3OSA5LjA5MDQ5MjY2NzE1MzYzOCAxMi41MzAwMDAwMDAwMDAwMDEgOS44NCBMIDE0LjE2IDguNjggQyAxMy4yNjYzNjI4OTYxOTUxNTEgNy40MjE4MTY5ODQ1ODQwNDEgMTEuODQxODAwOTA3ODM4MzIzIDYuNjQ2Nzk2MjEzNzE2MzM1NCAxMC4zIDYuNTggQyA3LjM0Mzg3ODYxMTY4MDIzIDYuNTUxOTgzNTI5MTIyODcyIDQuODYwNTEwMjI2MDc1NzUyNCA4Ljc5NjE0ODMwNDkwNTU1NCA0LjU5MDAwMDAwMDAwMDAwMSAxMS43NDAwMDAwMDAwMDAwMDIgQyA0LjQyNjkzNTkwNTg0MTAzOCAxMy4xODc5NjA4OTQ2NDg5MzEgNC44NzY1MDE3ODg3MTIxNCAxNC42MzgxNzM0MjAwMzk1ODQgNS44MzAwMDAwMDAwMDAwMDEgMTUuNzQgQyA2LjczMjkwMjI4MjkyNjQwMjUgMTYuNzY0NDc0NDY2MDY4NTA2IDguMDE1NTM1MTc1OTc1MTkzIDE3LjM3NTA3OTk4NDE2Nzc5IDkuMzc5OTk5OTk5OTk5OTk5IDE3LjQzIEwgOS41OCAxNy40MyBDIDExLjM0ODQzMjQ4OTI3MTg0NyAxNy4zODY0MDIyMDk5ODIwNzcgMTIuOTkwMTUyNzY4MzY3NTA1IDE2LjUwMjM5ODk4Mjc3NjcyIDEzLjk5OTk5OTk5OTk5OTk5OCAxNS4wNTAwMDAwMDAwMDAwMDIgQyAxNC4xODMzMTczNjI3MzY0MzcgMTUuNDA4NDcwNjEyNjQ3ODg2IDE0LjQwODE5ODM0MTk1MzEyOCAxNS43NDQxMTM4NjUyMTAxMDggMTQuNjcwMDAwMDAwMDAwMDAyIDE2LjA1IEMgMTUuNTcyOTAyMjgyOTI2NDAxIDE3LjA3NDQ3NDQ2NjA2ODUwNSAxNi44NTU1MzUxNzU5NzUxOSAxNy42ODUwNzk5ODQxNjc3OSAxOC4yMiAxNy43NDAwMDAwMDAwMDAwMDIgTCAxOC40MTk5OTk5OTk5OTk5OTggMTcuNzQwMDAwMDAwMDAwMDAyIEMgMjEuMzIxMTEzMTgxMDE5Mjc4IDE3LjcwNjYzMjM2OTEyMDg2OCAyMy43Mjg5OTQwNTcyMzUxNjMgMTUuNDg4NjIwMjM1ODMyMzk2IDI0IDEyLjU5OTk5OTk5OTk5OTk5OCBDIDI0LjE1MjAyMTY0MjQxNTg2OCAxMS4xNTEwNDc5MTgzODYzNiAyMy42OTE1ODk3OTExNzYyOSA5LjcwNDQ5NDMwNzAxMTYyNSAyMi43MyA4LjYxIFogTSAyMiAxMi40MSBDIDIxLjg0ODQ1MTcyNjkzNzg1NiAxNC4zMDYyNjY1NDI4Nzg1MTEgMjAuMjYyMzAzMTEwNTY0NDk2IDE1Ljc2NjA0NjE3NjA3OTI2OCAxOC4zNiAxNS43NiBDIDE3LjU0Njk2Mjc0MjgwMTE0MiAxNS43Mjc5NTU3MDk5MjIzODUgMTYuNzgxODE0NDI1ODY3MjA0IDE1LjM2NzAzNjY5MjUwMDcxNyAxNi4yNCAxNC43NiBDIDE1LjY1Mjk0MzU3NTk3MTg3MyAxNC4wNzA5Njg5MzI4NjAzNzYgMTUuMzc3NzcwNjM1ODgxMTg2IDEzLjE2OTQxNTQ4NDQwNTM1NiAxNS40Nzk5OTk5OTk5OTk5OTkgMTIuMjcgQyAxNS42MzEwNzQ0OTU2Njg4OTYgMTAuNDE5MjE2OTk5NzgxMjI0IDE3LjE0NDE5NDkyMzc2NjU4NCA4Ljk3NDg3NDc3Mjk2MDcwNyAxOSA4LjkxIEwgMTkuMTMgOC45MSBDIDE5Ljk0MzAzNzI1NzE5ODg1NiA4Ljk0MjA0NDI5MDA3NzYxNCAyMC43MDgxODU1NzQxMzI3OSA5LjMwMjk2MzMwNzQ5OTI4MSAyMS4yNSA5LjkwOTk5OTk5OTk5OTk5OCBDIDIxLjgzNjE1ODAxMDQyNDEzIDEwLjYwMzExMzQ0MDk0NzM4NCAyMi4xMDc4MzA5NDAyOTEzMDggMTEuNTA4Njg5ODczODM3OTg1IDIyIDEyLjQxIFoiCiAgICAgICAgICAgICAgICAgICAgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiAvPgogICAgICAgICAgICA8L2c+CiAgICAgICAgICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEgMCAwIDEgLTkuMzggLTIuODUpIj4KICAgICAgICAgICAgICAgIDxwb2x5Z29uCiAgICAgICAgICAgICAgICAgICAgc3R5bGU9InN0cm9rZTogbm9uZTsgc3Ryb2tlLWRhc2hhcnJheTogbm9uZTsgc3Ryb2tlLWxpbmVjYXA6IGJ1dHQ7IHN0cm9rZS1kYXNob2Zmc2V0OiAwOyBzdHJva2UtbGluZWpvaW46IG1pdGVyOyBzdHJva2UtbWl0ZXJsaW1pdDogNDsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyBzdHJva2Utd2lkdGg6IDA7IGZpbGw6IHJnYigwLCAxNzQsIDIxNyk7IgogICAgICAgICAgICAgICAgICAgIHBvaW50cz0iLTEuNjMsMC41IDEuNjMsMC41IDEuNjMsLTAuNSAtMC45NywtMC41IC0xLjYzLDAuNSAiIC8+CiAgICAgICAgICAgIDwvZz4KICAgICAgICAgICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSAwIDAgMSAtOS45OCAtMS4wNikiPgogICAgICAgICAgICAgICAgPHBvbHlnb24KICAgICAgICAgICAgICAgICAgICBzdHlsZT0ic3Ryb2tlOiBub25lOyBzdHJva2UtZGFzaGFycmF5OiBub25lOyBzdHJva2UtbGluZWNhcDogYnV0dDsgc3Ryb2tlLWRhc2hvZmZzZXQ6IDA7IHN0cm9rZS1saW5lam9pbjogbWl0ZXI7IHN0cm9rZS1taXRlcmxpbWl0OiA0OyBmaWxsLXJ1bGU6IG5vbnplcm87IG9wYWNpdHk6IDE7IHN0cm9rZS13aWR0aDogMDsgZmlsbDogcmdiKDAsIDE3NCwgMjE3KTsiCiAgICAgICAgICAgICAgICAgICAgcG9pbnRzPSItMi4wMiwwLjUgMi4wMiwwLjUgMi4wMiwtMC41IC0xLjUyLC0wLjUgLTIuMDIsMC41ICIgLz4KICAgICAgICAgICAgPC9nPgogICAgICAgICAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgxIDAgMCAxIC05LjA0IDAuNzIpIj4KICAgICAgICAgICAgICAgIDxwb2x5Z29uCiAgICAgICAgICAgICAgICAgICAgc3R5bGU9InN0cm9rZTogbm9uZTsgc3Ryb2tlLWRhc2hhcnJheTogbm9uZTsgc3Ryb2tlLWxpbmVjYXA6IGJ1dHQ7IHN0cm9rZS1kYXNob2Zmc2V0OiAwOyBzdHJva2UtbGluZWpvaW46IG1pdGVyOyBzdHJva2UtbWl0ZXJsaW1pdDogNDsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyBzdHJva2Utd2lkdGg6IDA7IGZpbGw6IHJnYigwLCAxNzQsIDIxNyk7IgogICAgICAgICAgICAgICAgICAgIHBvaW50cz0iLTAuOTYsMC41IDAuOTcsMC41IDAuOTcsLTAuNSAtMC4yNSwtMC41IC0wLjk2LDAuNSAiIC8+CiAgICAgICAgICAgIDwvZz4KICAgICAgICA8L2c+CiAgICA8L2c+Cjwvc3ZnPg==")),
                Technology.Create(new Identifier("ffdb9b67-b99c-470f-8157-8c2a7acc4c62"), "Java",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1qYXZhIiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiAgICA8ZwogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDAuODAwMDAwMDExOTIwOTI5LCAwLCAwLCAwLjgwMDAwMDAxMTkyMDkyOSwgMTUuOTk5OTk5MDQ2MzI1Njg0LCAxNi4wMDA0NDI1MDQ4ODI4MTIpIj4KICAgICAgICA8ZyBzdHlsZT0iIj4KICAgICAgICAgICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSAwIDAgMSAtMS4zMiAtOS41NSkiPgogICAgICAgICAgICAgICAgPHBhdGgKICAgICAgICAgICAgICAgICAgICBzdHlsZT0ic3Ryb2tlOiBub25lOyBzdHJva2Utd2lkdGg6IDE7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyNDQsNjcsNTQpOyBmaWxsLXJ1bGU6IG5vbnplcm87IG9wYWNpdHk6IDE7IgogICAgICAgICAgICAgICAgICAgIHRyYW5zZm9ybT0iIHRyYW5zbGF0ZSgtMjIuNjgsIC0xNC40NSkiCiAgICAgICAgICAgICAgICAgICAgZD0iTSAyMy42NSAyNC44OTggQyAyMi42NTE5OTk5OTk5OTk5OTcgMjMuMjg5IDIxLjkyNzk5OTk5OTk5OTk5NyAyMS45NTUgMjAuOTI0OTk5OTk5OTk5OTk3IDE5LjQ0Mjk5OTk5OTk5OTk5OCBDIDE5LjIyOSAxNS4yIDMxLjI0IDExLjM2NiAyNi4zNyAzLjk5OSBDIDI4LjQ4MSA5LjA4ODAwMDAwMDAwMDAwMSAxOC43OTMgMTIuMjM0IDE3Ljg5MyAxNi40NzIgQyAxNy4wNyAyMC4zNyAyMy42NDUgMjQuODk4IDIzLjY1IDI0Ljg5OCB6IgogICAgICAgICAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgICAgICAgICAgPC9nPgogICAgICAgICAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgxIDAgMCAxIDQuMzMgLTUuNjIpIj4KICAgICAgICAgICAgICAgIDxwYXRoCiAgICAgICAgICAgICAgICAgICAgc3R5bGU9InN0cm9rZTogbm9uZTsgc3Ryb2tlLXdpZHRoOiAxOyBzdHJva2UtZGFzaGFycmF5OiBub25lOyBzdHJva2UtbGluZWNhcDogYnV0dDsgc3Ryb2tlLWRhc2hvZmZzZXQ6IDA7IHN0cm9rZS1saW5lam9pbjogbWl0ZXI7IHN0cm9rZS1taXRlcmxpbWl0OiA0OyBmaWxsOiByZ2IoMjQ0LDY3LDU0KTsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyIKICAgICAgICAgICAgICAgICAgICB0cmFuc2Zvcm09IiB0cmFuc2xhdGUoLTI4LjMzLCAtMTguMzgpIgogICAgICAgICAgICAgICAgICAgIGQ9Ik0gMjMuODc4IDE3LjI3IEMgMjMuNjg2IDE5Ljc4NiAyNi4xMDcgMjEuMTI3IDI2LjE3NyAyMi45NjUgQyAyNi4yMzMgMjQuNDYxIDI0LjczIDI1LjcwOCAyNC43MyAyNS43MDggQyAyNC43MyAyNS43MDggMjcuNDU4MDAwMDAwMDAwMDAyIDI1LjE3MTk5OTk5OTk5OTk5NyAyOC4zMDkgMjIuODg5OTk5OTk5OTk5OTk3IEMgMjkuMjU0IDIwLjM1NTk5OTk5OTk5OTk5OCAyNi40NzUgMTguNjIwOTk5OTk5OTk5OTk1IDI2Ljc2MTAwMDAwMDAwMDAwMyAxNi41OTIgQyAyNy4wMjgwMDAwMDAwMDAwMDIgMTQuNjUzOTk5OTk5OTk5OTk4IDMyLjc5MiAxMS4wNDkgMzIuNzkyIDExLjA0OSBDIDMyLjc5MiAxMS4wNDkgMjQuMzExIDExLjYxMSAyMy44NzggMTcuMjcgeiIKICAgICAgICAgICAgICAgICAgICBzdHJva2UtbGluZWNhcD0icm91bmQiIC8+CiAgICAgICAgICAgIDwvZz4KICAgICAgICAgICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSAwIDAgMSAwLjYgNC40MSkiPgogICAgICAgICAgICAgICAgPHBhdGgKICAgICAgICAgICAgICAgICAgICBzdHlsZT0ic3Ryb2tlOiBub25lOyBzdHJva2Utd2lkdGg6IDE7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyMSwxMDEsMTkyKTsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyIKICAgICAgICAgICAgICAgICAgICB0cmFuc2Zvcm09IiB0cmFuc2xhdGUoLTI0LjYsIC0yOC40MSkiCiAgICAgICAgICAgICAgICAgICAgZD0iTSAzMi4wODQgMjUuMDU1IEMgMzMuODM4IDI0LjY2MSAzNS4zMTcgMjUuNzc4IDM1LjMxNyAyNy4wNjQ5OTk5OTk5OTk5OTggQyAzNS4zMTcgMjkuOTY1OTk5OTk5OTk5OTk4IDMxLjI5NiAzMi43MDggMzEuMjk2IDMyLjcwOCBDIDMxLjI5NiAzMi43MDggMzcuNTIxIDMxLjk2NTk5OTk5OTk5OTk5OCAzNy41MjEgMjcuMjAzIEMgMzcuNTIxIDI0LjA1MyAzNC40NjQgMjMuMjY2IDMyLjA4NCAyNS4wNTUgeiBNIDI5LjEyOSAyNy4zOTUgQyAyOS4xMjkgMjcuMzk1IDMxLjA3IDI2LjAxMiAzMS41ODcwMDAwMDAwMDAwMDMgMjUuNDkzIEMgMjYuODI0MDAwMDAwMDAwMDA1IDI2LjUwMzk5OTk5OTk5OTk5OCAxNS45NDkwMDAwMDAwMDAwMDMgMjYuNjM5OTk5OTk5OTk5OTk3IDE1Ljk0OTAwMDAwMDAwMDAwMyAyNS43NjE5OTk5OTk5OTk5OTcgQyAxNS45NDkwMDAwMDAwMDAwMDMgMjQuOTUyOTk5OTk5OTk5OTk2IDE5LjQ1NjAwMDAwMDAwMDAwMyAyNC4xMjM5OTk5OTk5OTk5OTUgMTkuNDU2MDAwMDAwMDAwMDAzIDI0LjEyMzk5OTk5OTk5OTk5NSBDIDE5LjQ1NjAwMDAwMDAwMDAwMyAyNC4xMjM5OTk5OTk5OTk5OTUgMTEuNjgzMDAwMDAwMDAwMDAzIDI0LjAxMTk5OTk5OTk5OTk5NyAxMS42ODMwMDAwMDAwMDAwMDMgMjYuMzA0OTk5OTk5OTk5OTk2IEMgMTEuNjgzIDI4LjY5NSAyMS44NTggMjguODY2IDI5LjEyOSAyNy4zOTUgeiIKICAgICAgICAgICAgICAgICAgICBzdHJva2UtbGluZWNhcD0icm91bmQiIC8+CiAgICAgICAgICAgIDwvZz4KICAgICAgICAgICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSAwIDAgMSAtMS41OCA2LjU2KSI+CiAgICAgICAgICAgICAgICA8cGF0aAogICAgICAgICAgICAgICAgICAgIHN0eWxlPSJzdHJva2U6IG5vbmU7IHN0cm9rZS13aWR0aDogMTsgc3Ryb2tlLWRhc2hhcnJheTogbm9uZTsgc3Ryb2tlLWxpbmVjYXA6IGJ1dHQ7IHN0cm9rZS1kYXNob2Zmc2V0OiAwOyBzdHJva2UtbGluZWpvaW46IG1pdGVyOyBzdHJva2UtbWl0ZXJsaW1pdDogNDsgZmlsbDogcmdiKDIxLDEwMSwxOTIpOyBmaWxsLXJ1bGU6IG5vbnplcm87IG9wYWNpdHk6IDE7IgogICAgICAgICAgICAgICAgICAgIHRyYW5zZm9ybT0iIHRyYW5zbGF0ZSgtMjIuNDIsIC0zMC41NikiCiAgICAgICAgICAgICAgICAgICAgZD0iTSAyNy45MzUgMjkuNTcxIEMgMjMuNDI2IDMxLjA3IDE1LjEyMDk5OTk5OTk5OTk5OSAzMC41OTEgMTcuNTgxIDI4LjU3ODAwMDAwMDAwMDAwMyBDIDE2LjM4MyAyOC41NzgwMDAwMDAwMDAwMDMgMTQuNjA3IDI5LjU0MTAwMDAwMDAwMDAwNCAxNC42MDcgMzAuNDY3MDAwMDAwMDAwMDAyIEMgMTQuNjA3IDMyLjMyNDAwMDAwMDAwMDAwNSAyMy41ODkgMzMuNzU4IDMwLjIzNzAwMDAwMDAwMDAwMiAzMS4wMzkgTCAyNy45MzUgMjkuNTcxIHoiCiAgICAgICAgICAgICAgICAgICAgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiAvPgogICAgICAgICAgICA8L2c+CiAgICAgICAgICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEgMCAwIDEgLTEuMiAxMC42MSkiPgogICAgICAgICAgICAgICAgPHBhdGgKICAgICAgICAgICAgICAgICAgICBzdHlsZT0ic3Ryb2tlOiBub25lOyBzdHJva2Utd2lkdGg6IDE7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyMSwxMDEsMTkyKTsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyIKICAgICAgICAgICAgICAgICAgICB0cmFuc2Zvcm09IiB0cmFuc2xhdGUoLTIyLjgsIC0zNC42MSkiCiAgICAgICAgICAgICAgICAgICAgZD0iTSAxOC42ODYgMzIuNzM5IEMgMTcuMDUgMzIuNzM5IDE1Ljk5MSAzMy43OTMgMTUuOTkxIDM0LjU2MSBDIDE1Ljk5MSAzNi45NTIgMjUuNzUwOTk5OTk5OTk5OTk4IDM3LjE5MyAyOS42MTgwMDAwMDAwMDAwMDIgMzQuNzY2IEwgMjcuMTYwMDAwMDAwMDAwMDA0IDMzLjEzNCBDIDI0LjI3MSAzNC40MDQgMTcuMDE0IDM0LjU3OSAxOC42ODYgMzIuNzM5IHoiCiAgICAgICAgICAgICAgICAgICAgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiAvPgogICAgICAgICAgICA8L2c+CiAgICAgICAgICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEgMCAwIDEgLTEuMzYgMTMuODkpIj4KICAgICAgICAgICAgICAgIDxwYXRoCiAgICAgICAgICAgICAgICAgICAgc3R5bGU9InN0cm9rZTogbm9uZTsgc3Ryb2tlLXdpZHRoOiAxOyBzdHJva2UtZGFzaGFycmF5OiBub25lOyBzdHJva2UtbGluZWNhcDogYnV0dDsgc3Ryb2tlLWRhc2hvZmZzZXQ6IDA7IHN0cm9rZS1saW5lam9pbjogbWl0ZXI7IHN0cm9rZS1taXRlcmxpbWl0OiA0OyBmaWxsOiByZ2IoMjEsMTAxLDE5Mik7IGZpbGwtcnVsZTogbm9uemVybzsgb3BhY2l0eTogMTsiCiAgICAgICAgICAgICAgICAgICAgdHJhbnNmb3JtPSIgdHJhbnNsYXRlKC0yMi42NCwgLTM3Ljg5KSIKICAgICAgICAgICAgICAgICAgICBkPSJNIDM2LjI4MSAzNi42MzIgQyAzNi4yODEgMzUuNjk2IDM1LjIyNiAzNS4yNTQ5OTk5OTk5OTk5OTUgMzQuODQ4IDM1LjA0NCBDIDM3LjA3NiA0MC40MTY5OTk5OTk5OTk5OTQgMTIuNTMwOTk5OTk5OTk5OTk5IDQwIDEyLjUzMDk5OTk5OTk5OTk5OSAzNi44Mjc5OTk5OTk5OTk5OTYgQyAxMi41MzA5OTk5OTk5OTk5OTkgMzYuMTA3IDE0LjMzOCAzNS40MDA5OTk5OTk5OTk5OTYgMTYuMDA4IDM1LjczNSBMIDE0LjU4OCAzNC44OTYgQyAxMS4yNiAzNC4zNzQgOSAzNS44MzcgOSAzNy4wMTcgQyA5IDQyLjUyIDM2LjI4MSA0Mi4yNTUgMzYuMjgxIDM2LjYzMiB6IgogICAgICAgICAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgICAgICAgICAgPC9nPgogICAgICAgICAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgxIDAgMCAxIDIuMzggMTcuMykiPgogICAgICAgICAgICAgICAgPHBhdGgKICAgICAgICAgICAgICAgICAgICBzdHlsZT0ic3Ryb2tlOiBub25lOyBzdHJva2Utd2lkdGg6IDE7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyMSwxMDEsMTkyKTsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyIKICAgICAgICAgICAgICAgICAgICB0cmFuc2Zvcm09IiB0cmFuc2xhdGUoLTI2LjM4LCAtNDEuMykiCiAgICAgICAgICAgICAgICAgICAgZD0iTSAzOSAzOC42MDQgQyAzNC44NTQgNDIuNjk5IDI0LjM0MSA0NC4xOTEgMTMuNzY4OTk5OTk5OTk5OTk4IDQxLjY2MSBDIDI0LjM0MSA0Ni4xNjQgMzguOTUgNDMuNjI4IDM5IDM4LjYwNCB6IgogICAgICAgICAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgICAgICAgICAgPC9nPgogICAgICAgIDwvZz4KICAgIDwvZz4KPC9zdmc+")),
                Technology.Create(new Identifier("e14b77ae-d7c7-41f1-a0f5-ee882f766400"), "JavaScript",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1qYXZhc2NyaXB0IiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgwLjg4ODg4OTAxNDcyMDkxNjcsIDAsIDAsIDAuODg4ODg5MDE0NzIwOTE2NywgMTYsIDE2KSI+CiAgICAgICAgPGcgc3R5bGU9IiI+CiAgICAgICAgICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEgMCAwIDEgMCAwKSI+CiAgICAgICAgICAgICAgICA8cGF0aAogICAgICAgICAgICAgICAgICAgIHN0eWxlPSJzdHJva2U6IG5vbmU7IHN0cm9rZS13aWR0aDogMTsgc3Ryb2tlLWRhc2hhcnJheTogbm9uZTsgc3Ryb2tlLWxpbmVjYXA6IGJ1dHQ7IHN0cm9rZS1kYXNob2Zmc2V0OiAwOyBzdHJva2UtbGluZWpvaW46IG1pdGVyOyBzdHJva2UtbWl0ZXJsaW1pdDogNDsgZmlsbDogcmdiKDI1NSwyMTQsMCk7IGZpbGwtcnVsZTogbm9uemVybzsgb3BhY2l0eTogMTsiCiAgICAgICAgICAgICAgICAgICAgdHJhbnNmb3JtPSIgdHJhbnNsYXRlKC0yNCwgLTI0KSIgZD0iTSA2IDQyIEwgNiA2IEwgNDIgNiBMIDQyIDQyIEwgNiA0MiB6IgogICAgICAgICAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgICAgICAgICAgPC9nPgogICAgICAgICAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgxIDAgMCAxIDIuNjcgNikiPgogICAgICAgICAgICAgICAgPHBhdGgKICAgICAgICAgICAgICAgICAgICBzdHlsZT0ic3Ryb2tlOiBub25lOyBzdHJva2Utd2lkdGg6IDE7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigwLDAsMSk7IGZpbGwtcnVsZTogbm9uemVybzsgb3BhY2l0eTogMTsiCiAgICAgICAgICAgICAgICAgICAgdHJhbnNmb3JtPSIgdHJhbnNsYXRlKC0yNi42NywgLTMwKSIKICAgICAgICAgICAgICAgICAgICBkPSJNIDI5LjUzOCAzMi45NDcgQyAzMC4yMyAzNC4wNzEwMDAwMDAwMDAwMDUgMzAuOTgyIDM1LjE0OCAzMi41NzUgMzUuMTQ4IEMgMzMuOTEzMDAwMDAwMDAwMDA0IDM1LjE0OCAzNC42MTUgMzQuNDgzMDAwMDAwMDAwMDA0IDM0LjYxNSAzMy41NjMgQyAzNC42MTUgMzIuNDYyIDMzLjg4OSAzMi4wNzEwMDAwMDAwMDAwMDUgMzIuNDE3IDMxLjQzMDAwMDAwMDAwMDAwMyBMIDMxLjYxMDAwMDAwMDAwMDAwMyAzMS4wODYwMDAwMDAwMDAwMDIgQyAyOS4yODEwMDAwMDAwMDAwMDIgMzAuMDk4MDAwMDAwMDAwMDAzIDI3LjczMjAwMDAwMDAwMDAwMyAyOC44NjAwMDAwMDAwMDAwMDMgMjcuNzMyMDAwMDAwMDAwMDAzIDI2LjI0NSBDIDI3LjczMjAwMDAwMDAwMDAwMyAyMy44MzUgMjkuNTc3IDIyLjAwMSAzMi40NiAyMi4wMDEgQyAzNC41MTMgMjIuMDAxIDM1Ljk4OCAyMi43MTIgMzcuMDUyIDI0LjU3NCBMIDM0LjUzOCAyNi4xODEgQyAzMy45ODUgMjUuMTkzIDMzLjM4Njk5OTk5OTk5OTk5IDI0LjgwNDAwMDAwMDAwMDAwMiAzMi40NTk5OTk5OTk5OTk5OTQgMjQuODA0MDAwMDAwMDAwMDAyIEMgMzEuNTEzOTk5OTk5OTk5OTkyIDI0LjgwNDAwMDAwMDAwMDAwMiAzMC45MTQ5OTk5OTk5OTk5OTIgMjUuNDAxMDAwMDAwMDAwMDAzIDMwLjkxNDk5OTk5OTk5OTk5MiAyNi4xODEgQyAzMC45MTQ5OTk5OTk5OTk5OTIgMjcuMTQ1IDMxLjUxNDk5OTk5OTk5OTk5MyAyNy41MzUgMzIuODk5OTk5OTk5OTk5OTkgMjguMTMyIEwgMzMuNzA2OTk5OTk5OTk5OTk0IDI4LjQ3NjAwMDAwMDAwMDAwMyBDIDM2LjQ1MiAyOS42NDUgMzggMzAuODM5IDM4IDMzLjUyMyBDIDM4IDM2LjQxNSAzNS43MTYgMzggMzIuNjUgMzggQyAyOS42NTEgMzggMjcuOTQ4IDM2LjQ5NSAyNyAzNC42MzIgTCAyOS41MzggMzIuOTQ3IHogTSAxNy45NTIgMzMuMDI5IEMgMTguNDU4MDAwMDAwMDAwMDAyIDMzLjkzNSAxOS4yMjcgMzQuNjMyMDAwMDAwMDAwMDA1IDIwLjMzMzAwMDAwMDAwMDAwMiAzNC42MzIwMDAwMDAwMDAwMDUgQyAyMS4zOTEwMDAwMDAwMDAwMDIgMzQuNjMyMDAwMDAwMDAwMDA1IDIyLjAwMDAwMDAwMDAwMDAwNCAzNC4yMTQwMDAwMDAwMDAwMDYgMjIuMDAwMDAwMDAwMDAwMDA0IDMyLjU4OTAwMDAwMDAwMDAwNiBMIDIyLjAwMDAwMDAwMDAwMDAwNCAyMiBMIDI1LjMzMzAwMDAwMDAwMDAwNiAyMiBMIDI1LjMzMzAwMDAwMDAwMDAwNiAzMy4xMDEgQyAyNS4zMzMwMDAwMDAwMDAwMDYgMzYuNDY3OTk5OTk5OTk5OTk2IDIzLjM4MDAwMDAwMDAwMDAwNiAzOCAyMC41MjgwMDAwMDAwMDAwMDYgMzggQyAxNy45NTEwMDAwMDAwMDAwMDggMzggMTYuMDkxMDAwMDAwMDAwMDA1IDM2LjI1NCAxNS4zMzMwMDAwMDAwMDAwMDYgMzQuNjMyIEwgMTcuOTUyIDMzLjAyOSB6IgogICAgICAgICAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgICAgICAgICAgPC9nPgogICAgICAgIDwvZz4KICAgIDwvZz4KPC9zdmc+")),
                Technology.Create(new Identifier("2c9c897d-b68e-4662-b1c5-d3ce12435cb5"), "Mobile",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1tb2JpbGUiIHZpZXdCb3g9IjAgMCAzMiAzMiIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEuNDU0NTQ1MDIxMDU3MTI5LCAwLCAwLCAxLjQ1NDU0NTAyMTA1NzEyOSwgMTYsIDE2KSI+CiAgICAgICAgPHBhdGgKICAgICAgICAgICAgc3R5bGU9InN0cm9rZTogbm9uZTsgc3Ryb2tlLWRhc2hhcnJheTogbm9uZTsgc3Ryb2tlLWxpbmVjYXA6IGJ1dHQ7IHN0cm9rZS1kYXNob2Zmc2V0OiAwOyBzdHJva2UtbGluZWpvaW46IG1pdGVyOyBzdHJva2UtbWl0ZXJsaW1pdDogNDsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyBzdHJva2Utd2lkdGg6IDBweDsgZmlsbDogcmdiKDE5OCwgMCwgMjE0KTsiCiAgICAgICAgICAgIHRyYW5zZm9ybT0iIHRyYW5zbGF0ZSgtMTIsIC0xMikiCiAgICAgICAgICAgIGQ9Ik0gMTYuNSAxIEwgNy41IDEgQyA2LjEyIDEgNSAyLjEyIDUgMy41IEwgNSAyMC41IEMgNSAyMS44OCA2LjEyIDIzIDcuNSAyMyBMIDE2LjUgMjMgQyAxNy44OCAyMyAxOSAyMS44OCAxOSAyMC41IEwgMTkgMy41IEMgMTkgMi4xMiAxNy44OCAxIDE2LjUgMSB6IE0gMTIgMjEuMTI1IEMgMTEuMzc4IDIxLjEyNSAxMC44NzUgMjAuNjIyIDEwLjg3NSAyMCBDIDEwLjg3NSAxOS4zNzggMTEuMzc4IDE4Ljg3NSAxMiAxOC44NzUgQyAxMi42MjIgMTguODc1IDEzLjEyNSAxOS4zNzggMTMuMTI1IDIwIEMgMTMuMTI1IDIwLjYyMiAxMi42MjIgMjEuMTI1IDEyIDIxLjEyNSB6IE0gMTcgMTggTCA3IDE4IEwgNyA0IEwgMTcgNCBMIDE3IDE4IHoiCiAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgIDwvZz4KPC9zdmc+")),
                Technology.Create(new Identifier("b03d26a3-4e1a-4044-90db-9b5970b6ce17"), "PHP",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1waHAiIHZpZXdCb3g9IjAgMCAzMiAzMiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KICAgIDxwYXRoCiAgICAgICAgZD0iTTAgMTZDMCAyMC42NDgzIDcuMTYzNSAyNC40MTY4IDE2IDI0LjQxNjhDMjQuODM2NSAyNC40MTY4IDMyIDIwLjY0ODMgMzIgMTZDMzIgMTEuMzUxOCAyNC44MzYzIDcuNTgzMjUgMTYgNy41ODMyNUM3LjE2Mzc1IDcuNTgzMjUgMCAxMS4zNTE4IDAgMTZaIgogICAgICAgIGZpbGw9InVybCgjcGFpbnQwX3JhZGlhbF8yNTdfMTIpIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDguODgxNzg0MTk3MDAxMjUyZS0xNiwgOC44ODE3ODQxOTcwMDEyNTJlLTE2KSIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTTE2IDIzLjc5MThDMjQuNDkxMyAyMy43OTE4IDMxLjM3NSAyMC4zMDMgMzEuMzc1IDE2QzMxLjM3NSAxMS42OTY1IDI0LjQ5MTMgOC4yMDgyNSAxNiA4LjIwODI1QzcuNTA4NzUgOC4yMDgyNSAwLjYyNSAxMS42OTY1IDAuNjI1IDE2QzAuNjI1IDIwLjMwMyA3LjUwODc1IDIzLjc5MTggMTYgMjMuNzkxOFoiCiAgICAgICAgZmlsbD0iIzc3N0JCMyIgc3R5bGU9InN0cm9rZS13aWR0aDogMHB4OyIKICAgICAgICB0cmFuc2Zvcm09Im1hdHJpeCgxLCAwLCAwLCAxLCA4Ljg4MTc4NDE5NzAwMTI1MmUtMTYsIDguODgxNzg0MTk3MDAxMjUyZS0xNikiIC8+CiAgICA8cGF0aAogICAgICAgIGQ9Ik04LjY5MzAxIDE2Ljk2NkM5LjM5MTI2IDE2Ljk2NiA5LjkxMjI2IDE2LjgzNzMgMTAuMjQyIDE2LjU4MzVDMTAuNTY4NSAxNi4zMzIgMTAuNzkzOCAxNS44OTY4IDEwLjkxMiAxNS4yODk4QzExLjAyMiAxNC43MjIzIDEwLjk4IDE0LjMyNjMgMTAuNzg3IDE0LjExMjNDMTAuNTkgMTMuODkzOCAxMC4xNjM4IDEzLjc4MyA5LjUyMDI2IDEzLjc4M0g4LjQwNDI2TDcuNzg2MDEgMTYuOTY2SDguNjkzMDFaTTUuMDQzMjYgMjAuODg2OEM1LjAxNzY2IDIwLjg4NjcgNC45OTIzOCAyMC44ODEgNC45NjkyMyAyMC44NzAxQzQuOTQ2MDkgMjAuODU5MSA0LjkyNTY3IDIwLjg0MzIgNC45MDk0MiAyMC44MjM0QzQuODkzMTcgMjAuODAzNiA0Ljg4MTUgMjAuNzgwNCA0Ljg3NTI1IDIwLjc1NTZDNC44Njg5OSAyMC43MzA4IDQuODY4MzIgMjAuNzA0OSA0Ljg3MzI2IDIwLjY3OThMNi41MTI1MSAxMi4yNDUzQzYuNTIwMjYgMTIuMjA1OCA2LjU0MTQzIDEyLjE3MDMgNi41NzI0MyAxMi4xNDQ3QzYuNjAzNDMgMTIuMTE5MiA2LjY0MjMzIDEyLjEwNTEgNi42ODI1MSAxMi4xMDVIMTAuMjE2QzExLjMyNjUgMTIuMTA1IDEyLjE1MyAxMi40MDY1IDEyLjY3MjggMTMuMDAxM0MxMy4xOTQ4IDEzLjU5ODggMTMuMzU2MyAxNC40MzQ4IDEzLjE1MiAxNS40ODVDMTMuMDY4OCAxNS45MTI4IDEyLjkyNTggMTYuMzEgMTIuNzI3IDE2LjY2NkMxMi41MjAyIDE3LjAzMjIgMTIuMjU2MiAxNy4zNjMxIDExLjk0NSAxNy42NDZDMTEuNTYyMyAxOC4wMDQgMTEuMTI5IDE4LjI2NCAxMC42NTgzIDE4LjQxNjhDMTAuMTk1MyAxOC41Njc4IDkuNjAwMjYgMTguNjQ0MyA4Ljg5MDc2IDE4LjY0NDNINy40NTk3Nkw3LjA1MTI2IDIwLjc0NjNDNy4wNDM1NSAyMC43ODU4IDcuMDIyMzIgMjAuODIxNSA2Ljk5MTIyIDIwLjg0NzFDNi45NjAxMSAyMC44NzI3IDYuOTIxMDYgMjAuODg2OCA2Ljg4MDc2IDIwLjg4NjhINS4wNDMyNloiCiAgICAgICAgZmlsbD0iYmxhY2siIHN0eWxlPSJzdHJva2Utd2lkdGg6IDBweDsiCiAgICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMSwgMCwgMCwgMSwgOC44ODE3ODQxOTcwMDEyNTJlLTE2LCA4Ljg4MTc4NDE5NzAwMTI1MmUtMTYpIiAvPgogICAgPHBhdGgKICAgICAgICBkPSJNOC41NDc1IDEzLjk1NjVIOS41MjAyNkMxMC4yOTcgMTMuOTU2NSAxMC41NjY4IDE0LjEyNyAxMC42NTg1IDE0LjIyODdDMTAuODEwMyAxNC4zOTcyIDEwLjgzOTMgMTQuNzUzIDEwLjc0MTMgMTUuMjU2N0MxMC42MzE1IDE1LjgyMSAxMC40MjggMTYuMjIxMiAxMC4xMzYzIDE2LjQ0NTdDOS44Mzc3NSAxNi42NzU3IDkuMzUxNzYgMTYuNzkyMiA4LjY5MzAxIDE2Ljc5MjJINy45OTY1MUw4LjU0NzUgMTMuOTU2NVpNMTAuMjE2IDExLjkzMTVINi42ODI3NkM2LjYwMjE4IDExLjkzMTUgNi41MjQxMSAxMS45NTk1IDYuNDYxOTEgMTIuMDEwN0M2LjM5OTcxIDEyLjA2MTkgNi4zNTcyMyAxMi4xMzMyIDYuMzQxNzYgMTIuMjEyMkw0LjcwMjUxIDIwLjY0N0M0LjY5MjgyIDIwLjY5NzIgNC42OTQzNiAyMC43NDkgNC43MDcgMjAuNzk4NkM0LjcxOTYzIDIwLjg0ODIgNC43NDMwNyAyMC44OTQzIDQuNzc1NjIgMjAuOTMzOEM0LjgwODE3IDIwLjk3MzMgNC44NDkwNCAyMS4wMDUxIDQuODk1MyAyMS4wMjdDNC45NDE1NyAyMS4wNDg4IDQuOTkyMDkgMjEuMDYwMiA1LjA0MzI2IDIxLjA2MDJINi44ODA3NkM2Ljk2MTMyIDIxLjA2MDIgNy4wMzkzNiAyMS4wMzIxIDcuMTAxNTEgMjAuOTgwOEM3LjE2MzY3IDIwLjkyOTYgNy4yMDYwOSAyMC44NTgzIDcuMjIxNTEgMjAuNzc5Mkw3LjYwMjc2IDE4LjgxNzdIOC44OTA1MUM5LjYxODUxIDE4LjgxNzcgMTAuMjMxNSAxOC43MzgyIDEwLjcxMjMgMTguNTgxN0MxMS4yMDY1IDE4LjQyMTIgMTEuNjYxMyAxOC4xNDkgMTIuMDYzOCAxNy43NzI1QzEyLjM4NzkgMTcuNDc3NCAxMi42NjI5IDE3LjEzMjUgMTIuODc4NSAxNi43NTA3QzEzLjA4NjMgMTYuMzc5IDEzLjIzNTggMTUuOTY0IDEzLjMyMjMgMTUuNTE4QzEzLjUzNzMgMTQuNDEyMiAxMy4zNjI1IDEzLjUyNyAxMi44MDMzIDEyLjg4N0MxMi4yNDkzIDEyLjI1MjcgMTEuMzc4OCAxMS45MzEyIDEwLjIxNiAxMS45MzEyVjExLjkzMTVaTTcuNTc1MjYgMTcuMTM5Mkg4LjY5MzAxQzkuNDMzODQgMTcuMTM5NCA5Ljk4NTUgMTYuOTk5OCAxMC4zNDggMTYuNzIwNUMxMC43MTA1IDE2LjQ0MTUgMTAuOTU1MyAxNS45NzU2IDExLjA4MjUgMTUuMzIyN0MxMS4yMDM4IDE0LjY5NTcgMTEuMTQ4NCAxNC4yNTM0IDEwLjkxNjMgMTMuOTk1N0MxMC42ODM4IDEzLjczODEgMTAuMjE4NCAxMy42MDkyIDkuNTIwMjYgMTMuNjA5Mkg4LjI2MTI1TDcuNTc1MjYgMTcuMTM5MlpNMTAuMjE2MyAxMi4yNzhDMTEuMjc5MyAxMi4yNzggMTIuMDU0NSAxMi41NTcgMTIuNTQyIDEzLjExNUMxMy4wMjk1IDEzLjY3MyAxMy4xNzYyIDE0LjQ1MTggMTIuOTgyIDE1LjQ1MTVDMTIuOTAxNyAxNS44NjM1IDEyLjc2NjMgMTYuMjQgMTIuNTc1OCAxNi41ODFDMTIuMzg0OSAxNi45MjIzIDEyLjEzNTcgMTcuMjM0NiAxMS44MjggMTcuNTE3N0MxMS40NjEzIDE3Ljg2MTEgMTEuMDUzNyAxOC4xMDU3IDEwLjYwNSAxOC4yNTE1QzEwLjE1NjUgMTguMzk3NSA5LjU4NTA5IDE4LjQ3MDQgOC44OTA3NiAxOC40NzAySDcuMzE2NzZMNi44ODEwMSAyMC43MTI3SDUuMDQzNTFMNi42ODMwMSAxMi4yNzhIMTAuMjE2M1oiCiAgICAgICAgZmlsbD0id2hpdGUiIHN0eWxlPSJzdHJva2Utd2lkdGg6IDBweDsiCiAgICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMSwgMCwgMCwgMSwgOC44ODE3ODQxOTcwMDEyNTJlLTE2LCA4Ljg4MTc4NDE5NzAwMTI1MmUtMTYpIiAvPgogICAgPHBhdGgKICAgICAgICBkPSJNMTcuMzY0OCAxOC42NDQyQzE3LjMzOTEgMTguNjQ0MyAxNy4zMTM4IDE4LjYzODYgMTcuMjkwNyAxOC42Mjc3QzE3LjI2NzUgMTguNjE2OCAxNy4yNDcgMTguNjAwOSAxNy4yMzA3IDE4LjU4MTFDMTcuMjE0NCAxOC41NjE0IDE3LjIwMjcgMTguNTM4MiAxNy4xOTY0IDE4LjUxMzRDMTcuMTkwMSAxOC40ODg2IDE3LjE4OTQgMTguNDYyNiAxNy4xOTQzIDE4LjQzNzVMMTcuOTE5MyAxNC43MDU1QzE3Ljk4ODUgMTQuMzUwNSAxNy45NzE1IDE0LjA5NiAxNy44NzE4IDEzLjk4OEMxNy44MTA1IDEzLjkyMjIgMTcuNjI3IDEzLjgxMiAxNy4wODQzIDEzLjgxMkgxNS43NzAzTDE0Ljg1ODggMTguNTA0QzE0Ljg1MDkgMTguNTQzNSAxNC44Mjk2IDE4LjU3OTEgMTQuNzk4NSAxOC42MDQ2QzE0Ljc2NzMgMTguNjMwMSAxNC43MjgzIDE4LjY0NDEgMTQuNjg4IDE4LjY0NEgxMi44NjU1QzEyLjgzOTkgMTguNjQ0IDEyLjgxNDYgMTguNjM4NCAxMi43OTE1IDE4LjYyNzVDMTIuNzY4MyAxOC42MTY2IDEyLjc0NzggMTguNjAwNyAxMi43MzE1IDE4LjU4MUMxMi43MTUyIDE4LjU2MTIgMTIuNzAzNCAxOC41MzgxIDEyLjY5NzEgMTguNTEzM0MxMi42OTA3IDE4LjQ4ODUgMTIuNjg5OSAxOC40NjI2IDEyLjY5NDggMTguNDM3NUwxNC4zMzQzIDEwLjAwMjdDMTQuMzQyIDkuOTYzMjIgMTQuMzYzMyA5LjkyNzYzIDE0LjM5NDQgOS45MDIwNUMxNC40MjU1IDkuODc2NDcgMTQuNDY0NSA5Ljg2MjQ5IDE0LjUwNDggOS44NjI0OUgxNi4zMjczQzE2LjM1MjkgOS44NjI0NyAxNi4zNzgyIDkuODY4MTEgMTYuNDAxMyA5Ljg3OTAxQzE2LjQyNDUgOS44ODk5IDE2LjQ0NSA5LjkwNTc5IDE2LjQ2MTMgOS45MjU1MkMxNi40Nzc2IDkuOTQ1MjUgMTYuNDg5NCA5Ljk2ODM0IDE2LjQ5NTcgOS45OTMxNEMxNi41MDIxIDEwLjAxNzkgMTYuNTAyOCAxMC4wNDM4IDE2LjQ5OCAxMC4wNjlMMTYuMTAyNSAxMi4xMDVIMTcuNTE1OEMxOC41OTI1IDEyLjEwNSAxOS4zMjI1IDEyLjI5NDUgMTkuNzQ3OCAxMi42ODUyQzIwLjE4MSAxMy4wODM1IDIwLjMxNjUgMTMuNzIwMiAyMC4xNDk4IDE0LjU3ODVMMTkuMzg3IDE4LjUwNEMxOS4zNzkyIDE4LjU0MzUgMTkuMzU3OSAxOC41NzkgMTkuMzI2OCAxOC42MDQ1QzE5LjI5NTcgMTguNjMwMSAxOS4yNTY3IDE4LjY0NCAxOS4yMTY1IDE4LjY0NEwxNy4zNjQ4IDE4LjY0NDJaIgogICAgICAgIGZpbGw9ImJsYWNrIiB0cmFuc2Zvcm09Im1hdHJpeCgxLCAwLCAwLCAxLCA4Ljg4MTc4NDE5NzAwMTI1MmUtMTYsIDguODgxNzg0MTk3MDAxMjUyZS0xNikiCiAgICAgICAgc3R5bGU9InN0cm9rZS13aWR0aDogMHB4OyIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTTE2LjMyNzUgOS42ODg3NUgxNC41MDQ4QzE0LjQyNDIgOS42ODg3NyAxNC4zNDYxIDkuNzE2ODEgMTQuMjgzOSA5Ljc2ODA3QzE0LjIyMTYgOS44MTkzNCAxNC4xNzkyIDkuODkwNjMgMTQuMTYzOCA5Ljk2OTc1TDEyLjUyNDUgMTguNDA0M0MxMi41MTQ4IDE4LjQ1NDUgMTIuNTE2MyAxOC41MDYzIDEyLjUyODkgMTguNTU1OUMxMi41NDE1IDE4LjYwNTUgMTIuNTY1IDE4LjY1MTcgMTIuNTk3NSAxOC42OTEyQzEyLjYzMDEgMTguNzMwOCAxMi42NzEgMTguNzYyNiAxMi43MTcyIDE4Ljc4NDRDMTIuNzYzNSAxOC44MDYzIDEyLjgxNDEgMTguODE3NyAxMi44NjUzIDE4LjgxNzhIMTQuNjg4QzE0Ljc2ODYgMTguODE3NyAxNC44NDY3IDE4Ljc4OTcgMTQuOTA4OSAxOC43Mzg0QzE0Ljk3MTEgMTguNjg3MiAxNS4wMTM2IDE4LjYxNTkgMTUuMDI5IDE4LjUzNjhMMTUuOTEzMyAxMy45ODU1SDE3LjA4MzhDMTcuNjI1OCAxMy45ODU1IDE3LjczOTggMTQuMTAxMyAxNy43NDQgMTQuMTA2NUMxNy43NzcgMTQuMTQxNSAxNy44MjAzIDE0LjMwNTMgMTcuNzQ4OCAxNC42NzI1TDE3LjAyMzggMTguNDA0M0MxNy4wMTQgMTguNDU0NSAxNy4wMTU1IDE4LjUwNjMgMTcuMDI4MiAxOC41NTZDMTcuMDQwOCAxOC42MDU2IDE3LjA2NDMgMTguNjUxOCAxNy4wOTY4IDE4LjY5MTNDMTcuMTI5NCAxOC43MzA5IDE3LjE3MDMgMTguNzYyNyAxNy4yMTY3IDE4Ljc4NDVDMTcuMjYzIDE4LjgwNjQgMTcuMzEzNSAxOC44MTc3IDE3LjM2NDggMTguODE3OEgxOS4yMTY4QzE5LjI5NzMgMTguODE3NyAxOS4zNzU0IDE4Ljc4OTYgMTkuNDM3NSAxOC43MzgzQzE5LjQ5OTcgMTguNjg3MSAxOS41NDIxIDE4LjYxNTggMTkuNTU3NSAxOC41MzY4TDIwLjMyMDMgMTQuNjExOEMyMC40OTkgMTMuNjkwMyAyMC4zNDYgMTIuOTk5MyAxOS44NjUzIDEyLjU1NzVDMTkuNDA2MyAxMi4xMzYgMTguNjM3OCAxMS45MzEzIDE3LjUxNTggMTEuOTMxM0gxNi4zMTMzTDE2LjY2ODUgMTAuMTAyNUMxNi42NzgzIDEwLjA1MjIgMTYuNjc2OCAxMC4wMDA0IDE2LjY2NDIgOS45NTA3QzE2LjY1MTYgOS45MDEwNCAxNi42MjgxIDkuODU0NzggMTYuNTk1NSA5LjgxNTI0QzE2LjU2MyA5Ljc3NTcgMTYuNTIyIDkuNzQzODUgMTYuNDc1NyA5LjcyMTk5QzE2LjQyOTQgOS43MDAxMiAxNi4zNzg4IDkuNjg4NzcgMTYuMzI3NSA5LjY4ODc1Wk0xNi4zMjc1IDEwLjAzNjNMMTUuODkxOCAxMi4yNzgzSDE3LjUxNThDMTguNTM3NiAxMi4yNzgzIDE5LjI0MjMgMTIuNDU2NiAxOS42MyAxMi44MTMzQzIwLjAxOCAxMy4xNjk2IDIwLjEzNDUgMTMuNzQ3MSAxOS45Nzk1IDE0LjU0NThMMTkuMjE2NSAxOC40NzA1SDE3LjM2NDhMMTguMDkgMTQuNzM4NUMxOC4xNzI1IDE0LjMxNCAxOC4xNDIxIDE0LjAyNDUgMTcuOTk4OCAxMy44N0MxNy44NTU0IDEzLjcxNTcgMTcuNTUwNiAxMy42Mzg1IDE3LjA4NDMgMTMuNjM4NUgxNS42MjdMMTQuNjg4IDE4LjQ3MDNIMTIuODY1TDE0LjUwNDUgMTAuMDM1NUgxNi4zMjc1VjEwLjAzNjNaIgogICAgICAgIGZpbGw9IndoaXRlIiBzdHlsZT0ic3Ryb2tlLXdpZHRoOiAwcHg7IgogICAgICAgIHRyYW5zZm9ybT0ibWF0cml4KDEsIDAsIDAsIDEsIDguODgxNzg0MTk3MDAxMjUyZS0xNiwgOC44ODE3ODQxOTcwMDEyNTJlLTE2KSIgLz4KICAgIDxwYXRoCiAgICAgICAgZD0iTTIzLjAzNCAxNi45NjZDMjMuNzMyMyAxNi45NjYgMjQuMjUzNSAxNi44MzczIDI0LjU4MzUgMTYuNTgzNUMyNC45MDk1IDE2LjMzMiAyNS4xMzUgMTUuODk2OCAyNS4yNTMzIDE1LjI4OThDMjUuMzYzMyAxNC43MjIzIDI1LjMyMTUgMTQuMzI2MyAyNS4xMjgzIDE0LjExMjNDMjQuOTMxMyAxMy44OTM4IDI0LjUwNSAxMy43ODMgMjMuODYxNSAxMy43ODNIMjIuNzQ1OEwyMi4xMjcgMTYuOTY2SDIzLjAzNFpNMTkuMzg1IDIwLjg4NjhDMTkuMzU5NCAyMC44ODY4IDE5LjMzNCAyMC44ODEyIDE5LjMxMDggMjAuODcwMkMxOS4yODc2IDIwLjg1OTMgMTkuMjY3MSAyMC44NDM0IDE5LjI1MDggMjAuODIzNkMxOS4yMzQ1IDIwLjgwMzggMTkuMjIyOCAyMC43ODA2IDE5LjIxNjUgMjAuNzU1N0MxOS4yMTAyIDIwLjczMDkgMTkuMjA5NiAyMC43MDQ5IDE5LjIxNDUgMjAuNjc5OEwyMC44NTM4IDEyLjI0NTNDMjAuODYxNSAxMi4yMDU3IDIwLjg4MjggMTIuMTcwMiAyMC45MTM5IDEyLjE0NDZDMjAuOTQ1IDEyLjExOSAyMC45ODQgMTIuMTA1IDIxLjAyNDMgMTIuMTA1SDI0LjU1NzVDMjUuNjY4IDEyLjEwNSAyNi40OTQ1IDEyLjQwNjUgMjcuMDE0IDEzLjAwMTNDMjcuNTM2MyAxMy41OTg4IDI3LjY5NzUgMTQuNDM0OCAyNy40OTMzIDE1LjQ4NUMyNy40MTUxIDE1Ljg5ODcgMjcuMjcxNyAxNi4yOTczIDI3LjA2ODUgMTYuNjY2QzI2Ljg2MTcgMTcuMDMyMiAyNi41OTc3IDE3LjM2MzEgMjYuMjg2NSAxNy42NDZDMjUuOTA0IDE4LjAwNCAyNS40NzAzIDE4LjI2NCAyNC45OTk4IDE4LjQxNjhDMjQuNTM2OCAxOC41Njc4IDIzLjk0MTggMTguNjQ0MyAyMy4yMzIgMTguNjQ0M0gyMS44MDEzTDIxLjM5MyAyMC43NDYzQzIxLjM4NTMgMjAuNzg1OSAyMS4zNjQgMjAuODIxNSAyMS4zMzI5IDIwLjg0NzJDMjEuMzAxNyAyMC44NzI4IDIxLjI2MjYgMjAuODg2OCAyMS4yMjIzIDIwLjg4NjhIMTkuMzg1WiIKICAgICAgICBmaWxsPSJibGFjayIgc3R5bGU9InN0cm9rZS13aWR0aDogMHB4OyIKICAgICAgICB0cmFuc2Zvcm09Im1hdHJpeCgxLCAwLCAwLCAxLCA4Ljg4MTc4NDE5NzAwMTI1MmUtMTYsIDguODgxNzg0MTk3MDAxMjUyZS0xNikiIC8+CiAgICA8cGF0aAogICAgICAgIGQ9Ik0yMi44ODg4IDEzLjk1NjVIMjMuODYxNUMyNC42MzgzIDEzLjk1NjUgMjQuOTA4IDE0LjEyNyAyNC45OTk1IDE0LjIyODdDMjUuMTUyIDE0LjM5NzIgMjUuMTgwNSAxNC43NTMgMjUuMDgyOCAxNS4yNTY3QzI0Ljk3MjggMTUuODIxIDI0Ljc2OTMgMTYuMjIxMiAyNC40Nzc1IDE2LjQ0NTdDMjQuMTc4OCAxNi42NzU3IDIzLjY5MjggMTYuNzkyMiAyMy4wMzQzIDE2Ljc5MjJIMjIuMzM3OEwyMi44ODg4IDEzLjk1NjVaTTI0LjU1NzMgMTEuOTMxNUgyMS4wMjRDMjAuOTQzNSAxMS45MzE2IDIwLjg2NTUgMTEuOTU5NiAyMC44MDMzIDEyLjAxMDhDMjAuNzQxMiAxMi4wNjIgMjAuNjk4NyAxMi4xMzMyIDIwLjY4MzMgMTIuMjEyMkwxOS4wNDM4IDIwLjY0N0MxOS4wMzQxIDIwLjY5NzMgMTkuMDM1NiAyMC43NDkgMTkuMDQ4MyAyMC43OTg2QzE5LjA2MDkgMjAuODQ4MiAxOS4wODQ0IDIwLjg5NDQgMTkuMTE2OSAyMC45MzM5QzE5LjE0OTUgMjAuOTczNCAxOS4xOTA0IDIxLjAwNTIgMTkuMjM2NyAyMS4wMjdDMTkuMjgzIDIxLjA0ODkgMTkuMzMzNiAyMS4wNjAyIDE5LjM4NDggMjEuMDYwMkgyMS4yMjIzQzIxLjMwMjggMjEuMDYwMiAyMS4zODA5IDIxLjAzMjEgMjEuNDQzIDIwLjk4MDhDMjEuNTA1MiAyMC45Mjk2IDIxLjU0NzYgMjAuODU4MyAyMS41NjMgMjAuNzc5MkwyMS45NDQzIDE4LjgxNzdIMjMuMjMxOEMyMy45NTk1IDE4LjgxNzcgMjQuNTcyOCAxOC43MzgyIDI1LjA1MzMgMTguNTgxN0MyNS41NDc4IDE4LjQyMTIgMjYuMDAyNSAxOC4xNDkgMjYuNDA1MyAxNy43NzIyQzI2LjcyOTMgMTcuNDc3MiAyNy4wMDQyIDE3LjEzMjMgMjcuMjE5OCAxNi43NTA3QzI3LjQyNzggMTYuMzc5IDI3LjU3NjggMTUuOTY0IDI3LjY2MzUgMTUuNTE4QzI3Ljg3ODUgMTQuNDEyMiAyNy43MDQgMTMuNTI3IDI3LjE0NDUgMTIuODg3QzI2LjU5MDUgMTIuMjUyNyAyNS43MjAzIDExLjkzMTIgMjQuNTU3IDExLjkzMTJMMjQuNTU3MyAxMS45MzE1Wk0yMS45MTY1IDE3LjEzOTJIMjMuMDM0QzIzLjc3NDggMTcuMTM5NCAyNC4zMjY3IDE2Ljk5OTggMjQuNjg5NSAxNi43MjA1QzI1LjA1MiAxNi40NDE1IDI1LjI5NjcgMTUuOTc1NiAyNS40MjM1IDE1LjMyMjdDMjUuNTQ1MyAxNC42OTU3IDI1LjQ4OTkgMTQuMjUzNCAyNS4yNTczIDEzLjk5NTdDMjUuMDI0NiAxMy43MzgxIDI0LjU1OTMgMTMuNjA5MiAyMy44NjE1IDEzLjYwOTJIMjIuNjAyOEwyMS45MTY1IDE3LjEzOTJaTTI0LjU1NzMgMTIuMjc4QzI1LjYyMDMgMTIuMjc4IDI2LjM5NTUgMTIuNTU3IDI2Ljg4MyAxMy4xMTVDMjcuMzcwNSAxMy42NzMgMjcuNTE3MSAxNC40NTE4IDI3LjMyMjggMTUuNDUxNUMyNy4yNDI4IDE1Ljg2MzUgMjcuMTA3NCAxNi4yNCAyNi45MTY4IDE2LjU4MUMyNi43MjYxIDE2LjkyMjMgMjYuNDc2OCAxNy4yMzQ2IDI2LjE2ODggMTcuNTE3N0MyNS44MDIxIDE3Ljg2MTEgMjUuMzk0NCAxOC4xMDU3IDI0Ljk0NTggMTguMjUxNUMyNC40OTc0IDE4LjM5NzUgMjMuOTI2MSAxOC40NzA0IDIzLjIzMTggMTguNDcwMkgyMS42NThMMjEuMjIxOCAyMC43MTI3SDE5LjM4NDNMMjEuMDIzOCAxMi4yNzhIMjQuNTU3M1oiCiAgICAgICAgZmlsbD0id2hpdGUiIHN0eWxlPSJzdHJva2Utd2lkdGg6IDBweDsiCiAgICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMSwgMCwgMCwgMSwgOC44ODE3ODQxOTcwMDEyNTJlLTE2LCA4Ljg4MTc4NDE5NzAwMTI1MmUtMTYpIiAvPgo8L3N2Zz4=")),
                Technology.Create(new Identifier("83f954f8-54b3-4b65-b8f3-982e9b17917a"), "Python",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1weXRob24iIHZpZXdCb3g9IjAgMCAzMiAzMiIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDAuODQyMDg1MDAzODUyODQ0MiwgMCwgMCwgMC44NDIwODUwMDM4NTI4NDQyLCAxNi4zNjc5OTI0MDExMjMwNDcsIDE2KSI+CiAgICAgICAgPGcgc3R5bGU9IiI+CiAgICAgICAgICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEgMCAwIDEgLTUuOTQgLTQuNSkiPgogICAgICAgICAgICAgICAgPHBhdGgKICAgICAgICAgICAgICAgICAgICBzdHlsZT0ic3Ryb2tlOiBub25lOyBzdHJva2Utd2lkdGg6IDE7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyLDExOSwxODkpOyBmaWxsLXJ1bGU6IG5vbnplcm87IG9wYWNpdHk6IDE7IgogICAgICAgICAgICAgICAgICAgIHRyYW5zZm9ybT0iIHRyYW5zbGF0ZSgtMTguMDYsIC0xOS41KSIKICAgICAgICAgICAgICAgICAgICBkPSJNIDI0LjA0NyA1IEMgMjIuNDkyIDUuMDA1IDIxLjQxNCA1LjE0MiAyMC4xMTEgNS4zNjcgQyAxNi4yNjMgNi4wMzcgMTUuNTYyMDAwMDAwMDAwMDAxIDcuNDQ0IDE1LjU2MjAwMDAwMDAwMDAwMSAxMC4wMzY5OTk5OTk5OTk5OTkgTCAxNS41NjIwMDAwMDAwMDAwMDEgMTQgTCAyNC41NjIgMTQgTCAyNC41NjIgMTYgTCAxNS4yMiAxNiBMIDEwLjg3MDAwMDAwMDAwMDAwMSAxNiBDIDguMjM0MDAwMDAwMDAwMDAyIDE2IDUuOTI3MDAwMDAwMDAwMDAxIDE3LjI0MiA1LjE5NjAwMDAwMDAwMDAwMSAyMC4yMTkgQyA0LjM3MDAwMDAwMDAwMDAwMSAyMy42MzYwMDAwMDAwMDAwMDMgNC4zMzMgMjUuNzc2MDAwMDAwMDAwMDAzIDUuMTk2MDAwMDAwMDAwMDAxIDI5LjM0NCBDIDUuODUxIDMyLjAwNSA3LjI5NCAzNCA5LjkzMSAzNCBMIDEzLjU2Mjk5OTk5OTk5OTk5OSAzNCBMIDEzLjU2Mjk5OTk5OTk5OTk5OSAyOC44OTYgQyAxMy41NjI5OTk5OTk5OTk5OTkgMjUuOTMgMTYuMjQ5IDIzIDE5LjMyNjk5OTk5OTk5OTk5OCAyMyBMIDI2LjU2MyAyMyBDIDI5LjA4NiAyMyAzMS41NjMgMjEuMTM3OTk5OTk5OTk5OTk4IDMxLjU2MyAxOC42MjMgTCAzMS41NjMgMTAuMDM3IEMgMzEuNTYzIDcuNTk4MDAwMDAwMDAwMDAxIDI5LjgwNCA1Ljc3NDAwMDAwMDAwMDAwMSAyNy4zNDUgNS4zNjUwMDAwMDAwMDAwMDEgQyAyNy40MDYgNS4zNTkgMjUuNTg5IDQuOTk0IDI0LjA0NyA1IHogTSAxOS4wNjMgOSBDIDE5Ljg4NCA5IDIwLjU2MyA5LjY3NyAyMC41NjMgMTAuNTAyIEMgMjAuNTYzIDExLjMzNSAxOS44ODQgMTIgMTkuMDYzIDEyIEMgMTguMjI2IDEyIDE3LjU2MyAxMS4zMzYgMTcuNTYzIDEwLjUwMiBDIDE3LjU2MyA5LjY4IDE4LjIyNiA5IDE5LjA2MyA5IHoiCiAgICAgICAgICAgICAgICAgICAgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiAvPgogICAgICAgICAgICA8L2c+CiAgICAgICAgICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEgMCAwIDEgNS4wNiA0LjUpIj4KICAgICAgICAgICAgICAgIDxwYXRoCiAgICAgICAgICAgICAgICAgICAgc3R5bGU9InN0cm9rZTogbm9uZTsgc3Ryb2tlLXdpZHRoOiAxOyBzdHJva2UtZGFzaGFycmF5OiBub25lOyBzdHJva2UtbGluZWNhcDogYnV0dDsgc3Ryb2tlLWRhc2hvZmZzZXQ6IDA7IHN0cm9rZS1saW5lam9pbjogbWl0ZXI7IHN0cm9rZS1taXRlcmxpbWl0OiA0OyBmaWxsOiByZ2IoMjU1LDE5Myw3KTsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyIKICAgICAgICAgICAgICAgICAgICB0cmFuc2Zvcm09IiB0cmFuc2xhdGUoLTI5LjA2LCAtMjguNSkiCiAgICAgICAgICAgICAgICAgICAgZD0iTSAyMy4wNzggNDMgQyAyNC42MzMgNDIuOTk1IDI1LjcxMSA0Mi44NTggMjcuMDE0IDQyLjYzMyBDIDMwLjg2MiA0MS45NjMgMzEuNTYzIDQwLjU1NjAwMDAwMDAwMDAwNCAzMS41NjMgMzcuOTYzIEwgMzEuNTYzIDM0IEwgMjIuNTYzIDM0IEwgMjIuNTYzIDMyIEwgMzEuOTA2IDMyIEwgMzYuMjU2IDMyIEMgMzguODkyIDMyIDQxLjE5OSAzMC43NTggNDEuOTMgMjcuNzgxIEMgNDIuNzU2IDI0LjM2Mzk5OTk5OTk5OTk5NyA0Mi43OTMgMjIuMjIzOTk5OTk5OTk5OTk3IDQxLjkzIDE4LjY1NiBDIDQxLjI3NCAxNS45OTUgMzkuODMxIDE0IDM3LjE5NCAxNCBMIDMzLjU2MjAwMDAwMDAwMDAwNSAxNCBMIDMzLjU2MjAwMDAwMDAwMDAwNSAxOS4xMDQgQyAzMy41NjIwMDAwMDAwMDAwMDUgMjIuMDcgMzAuODc2MDAwMDAwMDAwMDA1IDI1IDI3Ljc5ODAwMDAwMDAwMDAwNSAyNSBMIDIwLjU2MjAwMDAwMDAwMDAwNSAyNSBDIDE4LjAzOTAwMDAwMDAwMDAwNSAyNSAxNS41NjIwMDAwMDAwMDAwMDUgMjYuODYyMDAwMDAwMDAwMDAyIDE1LjU2MjAwMDAwMDAwMDAwNSAyOS4zNzcgTCAxNS41NjIwMDAwMDAwMDAwMDUgMzcuOTYzIEMgMTUuNTYyMDAwMDAwMDAwMDA1IDQwLjQwMiAxNy4zMjEwMDAwMDAwMDAwMDUgNDIuMjI2IDE5Ljc4MDAwMDAwMDAwMDAwNSA0Mi42MzUgQyAxOS43MTkgNDIuNjQxIDIxLjUzNiA0My4wMDYgMjMuMDc4IDQzIHogTSAyOC4wNjMgMzkgQyAyNy4yNDE5OTk5OTk5OTk5OTcgMzkgMjYuNTYzIDM4LjMyMyAyNi41NjMgMzcuNDk4IEMgMjYuNTYzIDM2LjY2NSAyNy4yNDE5OTk5OTk5OTk5OTcgMzYgMjguMDYzIDM2IEMgMjguOSAzNiAyOS41NjMgMzYuNjY0IDI5LjU2MyAzNy40OTggQyAyOS41NjMgMzguMzIgMjguODk5IDM5IDI4LjA2MyAzOSB6IgogICAgICAgICAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgICAgICAgICAgPC9nPgogICAgICAgIDwvZz4KICAgIDwvZz4KPC9zdmc+")),
                Technology.Create(new Identifier("6ed67e47-aeb5-4c29-a41c-ee6822280083"), "SQL",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1zcWwiIHZpZXdCb3g9IjAgMCAzMiAzMiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KICAgIDxwYXRoCiAgICAgICAgZD0iTSA4LjE0NSAzLjU5OSBDIDEwLjA5OSAyLjcxMSAxMi44NzcgMi4xMzMgMTYgMi4xMzMgQyAxOS4xMjMgMi4xMzMgMjEuOTAxIDIuNzA5IDIzLjg1NSAzLjU5OSBDIDI1LjkwNyA0LjUzMyAyNi42NjcgNS42MDQgMjYuNjY3IDYuNCBDIDI2LjY2NyA3LjE5OCAyNS45MDcgOC4yNjcgMjMuODU1IDkuMjAxIEMgMjEuOTAxIDEwLjA4OSAxOS4xMjMgMTAuNjY3IDE2IDEwLjY2NyBDIDEyLjg3NyAxMC42NjcgMTAuMDk5IDEwLjA5MSA4LjE0NSA5LjIwMSBDIDYuMDkzIDguMjY3IDUuMzMzIDcuMTk2IDUuMzMzIDYuNCBDIDUuMzMzIDUuNjAyIDYuMDkzIDQuNTMzIDguMTQ1IDMuNTk5IFogTSAyNi42NjcgMTAuMDIyIEwgMjYuNjY3IDEyLjggQyAyNi42NjcgMTMuNTk4IDI1LjkwNyAxNC42NjcgMjMuODU1IDE1LjYwMSBDIDIxLjkwMSAxNi40ODkgMTkuMTIzIDE3LjA2NyAxNiAxNy4wNjcgQyAxMi44NzcgMTcuMDY3IDEwLjA5OSAxNi40OTEgOC4xNDUgMTUuNjAxIEMgNi4wOTMgMTQuNjY3IDUuMzMzIDEzLjU5NiA1LjMzMyAxMi44IEwgNS4zMzMgMTAuMDIyIEMgNS45MTEgMTAuNDUzIDYuNTcxIDEwLjgyOSA3LjI2MiAxMS4xNDIgQyA5LjU1MyAxMi4xODMgMTIuNjQ0IDEyLjggMTYgMTIuOCBDIDE5LjM1NiAxMi44IDIyLjQ0NyAxMi4xODMgMjQuNzM4IDExLjE0MiBDIDI1LjQxOCAxMC44MzcgMjYuMDY1IDEwLjQ2MiAyNi42NjcgMTAuMDIyIFogTSAyOC44IDYuNCBDIDI4LjggNC4yNTIgMjYuOTMzIDIuNjU2IDI0LjczOCAxLjY1OCBDIDIyLjQ0NyAwLjYxNyAxOS4zNTYgMCAxNiAwIEMgMTIuNjQ0IDAgOS41NTMgMC42MTcgNy4yNjIgMS42NTggQyA1LjA2NyAyLjY1NiAzLjIgNC4yNTIgMy4yIDYuNCBMIDMuMiAyNS42IEMgMy4yIDI3Ljc0OCA1LjA2NyAyOS4zNDQgNy4yNjIgMzAuMzQyIEMgOS41NTMgMzEuMzgxIDEyLjY0NCAzMiAxNiAzMiBDIDE5LjM1NiAzMiAyMi40NDcgMzEuMzgzIDI0LjczOCAzMC4zNDIgQyAyNi45MzMgMjkuMzQ0IDI4LjggMjcuNzQ4IDI4LjggMjUuNiBMIDI4LjggNi40IFogTSAyNi42NjcgMTYuNDIyIEwgMjYuNjY3IDE5LjIgQyAyNi42NjcgMTkuOTk4IDI1LjkwNyAyMS4wNjcgMjMuODU1IDIyLjAwMSBDIDIxLjkwMSAyMi44ODkgMTkuMTIzIDIzLjQ2NyAxNiAyMy40NjcgQyAxMi44NzcgMjMuNDY3IDEwLjA5OSAyMi44OTEgOC4xNDUgMjIuMDAxIEMgNi4wOTMgMjEuMDY3IDUuMzMzIDE5Ljk5NiA1LjMzMyAxOS4yIEwgNS4zMzMgMTYuNDIyIEMgNS45MTEgMTYuODUzIDYuNTcxIDE3LjIyOSA3LjI2MiAxNy41NDIgQyA5LjU1MyAxOC41ODEgMTIuNjQ0IDE5LjIgMTYgMTkuMiBDIDE5LjM1NiAxOS4yIDIyLjQ0NyAxOC41ODMgMjQuNzM4IDE3LjU0MiBDIDI1LjQxOCAxNy4yMzcgMjYuMDY1IDE2Ljg2MiAyNi42NjcgMTYuNDIyIFogTSAyNi42NjcgMjIuODIyIEwgMjYuNjY3IDI1LjYgQyAyNi42NjcgMjYuMzk4IDI1LjkwNyAyNy40NjcgMjMuODU1IDI4LjQwMSBDIDIxLjkwMSAyOS4yODkgMTkuMTIzIDI5Ljg2NyAxNiAyOS44NjcgQyAxMi44NzcgMjkuODY3IDEwLjA5OSAyOS4yOTEgOC4xNDUgMjguNDAxIEMgNi4wOTMgMjcuNDY3IDUuMzMzIDI2LjM5NiA1LjMzMyAyNS42IEwgNS4zMzMgMjIuODIyIEMgNS45MTEgMjMuMjUzIDYuNTcxIDIzLjYyOSA3LjI2MiAyMy45NDIgQyA5LjU1MyAyNC45ODEgMTIuNjQ0IDI1LjYgMTYgMjUuNiBDIDE5LjM1NiAyNS42IDIyLjQ0NyAyNC45ODMgMjQuNzM4IDIzLjk0MiBDIDI1LjQyOSAyMy42MjkgMjYuMDg5IDIzLjI1MyAyNi42NjcgMjIuODIyIFoiCiAgICAgICAgZmlsbD0iIzAwNzlkNiIgc3R5bGU9InN0cm9rZS13aWR0aDogMHB4OyIKICAgICAgICB0cmFuc2Zvcm09Im1hdHJpeCgxLCAwLCAwLCAxLCA0LjQ0MDg5MjA5ODUwMDYyNmUtMTYsIDQuNDQwODkyMDk4NTAwNjI2ZS0xNikiIC8+Cjwvc3ZnPg==")),
                Technology.Create(new Identifier("288cc499-d3e8-4537-bc38-d02bc1a06625"), "Rust",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC1ydXN0IiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgwLjgwMDAwMDAxMTkyMDkyOSwgMCwgMCwgMC44MDAwMDAwMTE5MjA5MjksIDE2LCAxNikiPgogICAgICAgIDxwYXRoCiAgICAgICAgICAgIHN0eWxlPSJzdHJva2U6IG5vbmU7IHN0cm9rZS13aWR0aDogMTsgc3Ryb2tlLWRhc2hhcnJheTogbm9uZTsgc3Ryb2tlLWxpbmVjYXA6IGJ1dHQ7IHN0cm9rZS1kYXNob2Zmc2V0OiAwOyBzdHJva2UtbGluZWpvaW46IG1pdGVyOyBzdHJva2UtbWl0ZXJsaW1pdDogNDsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyIKICAgICAgICAgICAgdHJhbnNmb3JtPSIgdHJhbnNsYXRlKC0yNCwgLTI0KSIKICAgICAgICAgICAgZD0iTSA0Mi4xNjQgMjQgTCA0NCAyMi4wMyBMIDQxLjgxNSAyMC40NTYgTCA0My4yMzA5OTk5OTk5OTk5OTUgMTguMTY2IEwgNDAuNzgwOTk5OTk5OTk5OTkgMTcuMDQ5IEwgNDEuNzIyOTk5OTk5OTk5OTkgMTQuNTI3IEwgMzkuMTAxOTk5OTk5OTk5OTkgMTMuOTA4OTk5OTk5OTk5OTk5IEwgMzkuNTMzOTk5OTk5OTk5OTkgMTEuMjUxIEwgMzYuODQyOTk5OTk5OTk5OTkgMTEuMTU1OTk5OTk5OTk5OTk5IEwgMzYuNzQ3OTk5OTk5OTk5OTkgOC40NjUgTCAzNC4wODk5OTk5OTk5OTk5OSA4Ljg5NyBMIDMzLjQ3MTk5OTk5OTk5OTk5IDYuMjc2IEwgMzAuOTQ5OTk5OTk5OTk5OTkgNy4yMTggTCAyOS44MzI5OTk5OTk5OTk5ODggNC43NjggTCAyNy41NDI5OTk5OTk5OTk5OSA2LjE4Mzk5OTk5OTk5OTk5OSBMIDI1Ljk3IDQgTCAyNCA1LjgzNiBMIDIyLjAzIDQgTCAyMC40NTYgNi4xODUwMDAwMDAwMDAwMDA1IEwgMTguMTY2IDQuNzY5IEwgMTcuMDQ5IDcuMjE5IEwgMTQuNTI3IDYuMjc3IEwgMTMuOTA4OTk5OTk5OTk5OTk5IDguODk4IEwgMTEuMjUxIDguNDY2IEwgMTEuMTU1OTk5OTk5OTk5OTk5IDExLjE1NyBMIDguNDY1IDExLjI1MiBMIDguODk3IDEzLjkxIEwgNi4yNzYgMTQuNTI4IEwgNy4yMTggMTcuMDUgTCA0Ljc2OCAxOC4xNjcgTCA2LjE4Mzk5OTk5OTk5OTk5OSAyMC40NTcgTCA0IDIyLjAzIEwgNS44MzYgMjQgTCA0IDI1Ljk3IEwgNi4xODUwMDAwMDAwMDAwMDA1IDI3LjU0NCBMIDQuNzY5IDI5LjgzNCBMIDcuMjE5IDMwLjk1MSBMIDYuMjc3IDMzLjQ3MyBMIDguODk4IDM0LjA5MSBMIDguNDY2IDM2Ljc0OSBMIDExLjE1NyAzNi44NDQgTCAxMS4yNTIgMzkuNTM1MDAwMDAwMDAwMDA0IEwgMTMuOTEgMzkuMTAzIEwgMTQuNTI4IDQxLjcyNDAwMDAwMDAwMDAwNCBMIDE3LjA1IDQwLjc4MjAwMDAwMDAwMDAwNCBMIDE4LjE2NyA0My4yMzIwMDAwMDAwMDAwMDYgTCAyMC40NTcgNDEuODE2MDAwMDAwMDAwMDEgTCAyMi4wMyA0NCBMIDI0IDQyLjE2NCBMIDI1Ljk3IDQ0IEwgMjcuNTQ0IDQxLjgxNSBMIDI5LjgzNCA0My4yMzA5OTk5OTk5OTk5OTUgTCAzMC45NTEgNDAuNzgwOTk5OTk5OTk5OTkgTCAzMy40NzMgNDEuNzIyOTk5OTk5OTk5OTkgTCAzNC4wOTEgMzkuMTAxOTk5OTk5OTk5OTkgTCAzNi43NDkgMzkuNTMzOTk5OTk5OTk5OTkgTCAzNi44NDQgMzYuODQyOTk5OTk5OTk5OTkgTCAzOS41MzUwMDAwMDAwMDAwMDQgMzYuNzQ3OTk5OTk5OTk5OTkgTCAzOS4xMDMgMzQuMDg5OTk5OTk5OTk5OTkgTCA0MS43MjQwMDAwMDAwMDAwMDQgMzMuNDcxOTk5OTk5OTk5OTkgTCA0MC43ODIwMDAwMDAwMDAwMDQgMzAuOTQ5OTk5OTk5OTk5OTkgTCA0My4yMzIwMDAwMDAwMDAwMDYgMjkuODMyOTk5OTk5OTk5OTg4IEwgNDEuODE2MDAwMDAwMDAwMDEgMjcuNTQyOTk5OTk5OTk5OTkgTCA0NCAyNS45NyBMIDQyLjE2NCAyNCB6IE0gMjQgNyBDIDI0LjU1MiA3IDI1IDcuNDQ4IDI1IDggQyAyNSA4LjU1MiAyNC41NTIgOSAyNCA5IEMgMjMuNDQ4IDkgMjMgOC41NTIgMjMgOCBDIDIzIDcuNDQ4IDIzLjQ0OCA3IDI0IDcgeiBNIDkgMTggQyA5LjU1MiAxOCAxMCAxOC40NDggMTAgMTkgQyAxMCAxOS41NTIgOS41NTIgMjAgOSAyMCBDIDguNDQ4IDIwIDggMTkuNTUyIDggMTkgQyA4IDE4LjQ0OCA4LjQ0OCAxOCA5IDE4IHogTSA4LjgwOCAyOSBDIDguMjkgMjcuNDI2IDggMjUuNzQ4IDggMjQgQyA4IDIzLjI5NiA4LjA2MSAyMi42MDggOC4xNDkgMjEuOTI4IEwgMTAuODU1OTk5OTk5OTk5OTk4IDIwLjQ3OCBDIDExLjQwNTk5OTk5OTk5OTk5OSAyMC4xODQgMTEuNjc5OTk5OTk5OTk5OTk4IDE5LjU4MzAwMDAwMDAwMDAwMiAxMS41OTM5OTk5OTk5OTk5OTggMTkgTCAxMyAxOSBMIDEzIDI5IEwgOC44MDggMjkgeiBNIDE1IDM4IEMgMTQuNDQ4IDM4IDE0IDM3LjU1MiAxNCAzNyBDIDE0IDM2LjQ0OCAxNC40NDggMzYgMTUgMzYgQyAxNS41NTIgMzYgMTYgMzYuNDQ4IDE2IDM3IEMgMTYgMzcuNTUyIDE1LjU1MiAzOCAxNSAzOCB6IE0gMzMgMzggQyAzMi40NDggMzggMzIgMzcuNTUyIDMyIDM3IEMgMzIgMzYuNDQ4IDMyLjQ0OCAzNiAzMyAzNiBDIDMzLjU1MiAzNiAzNCAzNi40NDggMzQgMzcgQyAzNCAzNy41NTIgMzMuNTUyIDM4IDMzIDM4IHogTSAzNS40NDQgMzUuMTcxIEwgMzIuMzMyIDM0LjY3NCBDIDMxLjU0ODAwMDAwMDAwMDAwMiAzNC41NDkgMzAuODExIDM1LjA4MyAzMC42ODYgMzUuODY3IEwgMzAuMjI3IDM4Ljc0NCBDIDI4LjMxMyAzOS41NTIgMjYuMjA5IDQwIDI0IDQwIEMgMjEuNzQ0IDQwIDE5LjYgMzkuNTI4IDE3LjY1NCAzOC42ODYgTCAxNy4yMjQgMzUuOTk0IEMgMTcuMDk5IDM1LjIxIDE2LjM2MjAwMDAwMDAwMDAwMiAzNC42NzYgMTUuNTc4IDM0LjgwMSBMIDEyLjY0NTk5OTk5OTk5OTk5OSAzNS4yNjkwMDAwMDAwMDAwMDUgQyAxMS45NTQ5OTk5OTk5OTk5OTggMzQuNTczMDAwMDAwMDAwMDEgMTEuMzI2OTk5OTk5OTk5OTk4IDMzLjgxMyAxMC43NzMgMzIuOTk5IEwgMjMuOTUxIDMyLjk5OSBMIDIzLjk1MSAyOC45OTkwMDAwMDAwMDAwMDIgTCAyMCAyOC45OTkwMDAwMDAwMDAwMDIgTCAyMCAyNS45OTkwMDAwMDAwMDAwMDIgTCAyMi44NzIgMjUuOTk5MDAwMDAwMDAwMDAyIEMgMjguMzQ2IDI1Ljk5OTAwMDAwMDAwMDAwMiAyMy44NTg5OTk5OTk5OTk5OTggMzIuOTk5IDMxLjExOSAzMi45OTkgTCAzNy4yMjcgMzIuOTk5IEMgMzYuNjk3IDMzLjc3NyAzNi4wOTggMzQuNTAxIDM1LjQ0NCAzNS4xNzEgeiBNIDIwLjIzOCAyMiBMIDIwLjIzOCAxOSBMIDI1LjQzNiAxOSBDIDI2LjI1NiAxOSAyNi45MjEgMTkuNjY1IDI2LjkyMSAyMC40ODUgTCAyNi45MjEgMjAuNTE1IEMgMjYuOTIxIDIxLjMzNSAyNi4yNTYgMjIgMjUuNDM2IDIyIEwgMjAuMjM4IDIyIHogTSAzOS45MjcgMjUuNDM2IEwgMzcuMzE2IDI1LjQzNiBMIDM3LjMxNiAyNi42NjggQyAzNy4zMTYgMjguMDM4IDM2LjQ2MiAyOSAzNS40NzIgMjkgQyAzMi45MjUwMDAwMDAwMDAwMDQgMjkgMzMuNjE3MDAwMDAwMDAwMDA0IDI1LjQ2MyAzMC41MTkwMDAwMDAwMDAwMDIgMjMuOTIgQyAzMi44MzEgMjMuNTM5IDM0LjYwMyAyMS40OTAwMDAwMDAwMDAwMDIgMzQuNjAzIDE5IEMgMzQuNjAzIDE2LjIzOSAzMi40MzEwMDAwMDAwMDAwMDQgMTQgMjkuNzUyMDAwMDAwMDAwMDAyIDE0IEwgMjMuOTUwMDAwMDAwMDAwMDAzIDE0IEwgMTUuNzgyMDAwMDAwMDAwMDA0IDE0IEwgMTEuNTIwMDAwMDAwMDAwMDAzIDE0IEMgMTMuNzkyMDAwMDAwMDAwMDAzIDExLjE2OCAxNy4wMDMwMDAwMDAwMDAwMDQgOS4xMjM5OTk5OTk5OTk5OTkgMjAuNjg2MDAwMDAwMDAwMDAzIDguMzQ3OTk5OTk5OTk5OTk5IEwgMjIuOTgzMDAwMDAwMDAwMDA0IDEwLjY0NSBDIDIzLjU0NDAwMDAwMDAwMDAwNCAxMS4yMDYgMjQuNDU0MDAwMDAwMDAwMDA0IDExLjIwNiAyNS4wMTUwMDAwMDAwMDAwMDQgMTAuNjQ1IEwgMjcuMzEyMDAwMDAwMDAwMDA1IDguMzQ3OTk5OTk5OTk5OTk5IEMgMzEuOTUyMDAwMDAwMDAwMDA1IDkuMzI1OTk5OTk5OTk5OTk5IDM1Ljg1MjAwMDAwMDAwMDAwNCAxMi4zMDk5OTk5OTk5OTk5OTkgMzguMDU2MDAwMDAwMDAwMDA0IDE2LjM1NDk5OTk5OTk5OTk5NyBMIDM2Ljg4OSAxOC41MzI5OTk5OTk5OTk5OTggQyAzNi41MTQgMTkuMjMyOTk5OTk5OTk5OTk3IDM2Ljc3ODAwMDAwMDAwMDAwNiAyMC4xMDQgMzcuNDc3MDAwMDAwMDAwMDA0IDIwLjQ3Nzk5OTk5OTk5OTk5OCBMIDM5LjgxOSAyMS43MzIgQyAzOS45MjcgMjIuNDc1IDQwIDIzLjIyOCA0MCAyNCBDIDQwIDI0LjQ4NSAzOS45NyAyNC45NjIgMzkuOTI3IDI1LjQzNiB6IE0gMzkgMjAgQyAzOC40NDggMjAgMzggMTkuNTUyIDM4IDE5IEMgMzggMTguNDQ4IDM4LjQ0OCAxOCAzOSAxOCBDIDM5LjU1MiAxOCA0MCAxOC40NDggNDAgMTkgQyA0MCAxOS41NTIgMzkuNTUyIDIwIDM5IDIwIHoiCiAgICAgICAgICAgIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIgLz4KICAgIDwvZz4KPC9zdmc+")),
                Technology.Create(new Identifier("b0757f91-5be6-4da8-a98a-cfcc68099bde"), "TypeScript",
                    DecodeBase64(
                        "PHN2ZyBpZD0idGVjaC10eXBlc2NyaXB0IiB2aWV3Qm94PSIwIDAgMzIgMzIiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgwLjg4ODg4OTAxNDcyMDkxNjcsIDAsIDAsIDAuODg4ODg5MDE0NzIwOTE2NywgMTYsIDE2KSI+CiAgICAgICAgPGcgc3R5bGU9IiI+CiAgICAgICAgICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEgMCAwIDEgMCAwKSI+CiAgICAgICAgICAgICAgICA8cmVjdAogICAgICAgICAgICAgICAgICAgIHN0eWxlPSJzdHJva2U6IG5vbmU7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyNSwgMTE4LCAyMTApOyBmaWxsLXJ1bGU6IG5vbnplcm87IG9wYWNpdHk6IDE7IHN0cm9rZS13aWR0aDogMHB4OyIKICAgICAgICAgICAgICAgICAgICB4PSItMTgiIHk9Ii0xOCIgcng9IjAiIHJ5PSIwIiB3aWR0aD0iMzYiIGhlaWdodD0iMzYiIC8+CiAgICAgICAgICAgIDwvZz4KICAgICAgICAgICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSAwIDAgMSAtMy4xNCA3KSI+CiAgICAgICAgICAgICAgICA8cG9seWdvbgogICAgICAgICAgICAgICAgICAgIHN0eWxlPSJzdHJva2U6IG5vbmU7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyNTUsIDI1NSwgMjU1KTsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyBzdHJva2Utd2lkdGg6IDBweDsiCiAgICAgICAgICAgICAgICAgICAgcG9pbnRzPSI2LjYzLC05IC02LjYzLC05IC02LjYzLC01Ljc0IC0xLjg3LC01Ljc0IC0xLjg3LDkgMS44OSw5IDEuODksLTUuNzQgNi42MywtNS43NCAiIC8+CiAgICAgICAgICAgIDwvZz4KICAgICAgICAgICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMSAwIDAgMSAxMC4zNCA2Ljk5KSI+CiAgICAgICAgICAgICAgICA8cGF0aAogICAgICAgICAgICAgICAgICAgIHN0eWxlPSJzdHJva2U6IG5vbmU7IHN0cm9rZS1kYXNoYXJyYXk6IG5vbmU7IHN0cm9rZS1saW5lY2FwOiBidXR0OyBzdHJva2UtZGFzaG9mZnNldDogMDsgc3Ryb2tlLWxpbmVqb2luOiBtaXRlcjsgc3Ryb2tlLW1pdGVybGltaXQ6IDQ7IGZpbGw6IHJnYigyNTUsIDI1NSwgMjU1KTsgZmlsbC1ydWxlOiBub256ZXJvOyBvcGFjaXR5OiAxOyBzdHJva2Utd2lkdGg6IDBweDsiCiAgICAgICAgICAgICAgICAgICAgdHJhbnNmb3JtPSIgdHJhbnNsYXRlKC0zNC4zNCwgLTMwLjk5KSIKICAgICAgICAgICAgICAgICAgICBkPSJNIDM5LjE5NCAyNi4wODQgQyAzOS4xOTQgMjYuMDg0IDM3LjQwNzAwMDAwMDAwMDAwNCAyNC44OTIgMzUuMzg3IDI0Ljg5MiBDIDMzLjM2NyAyNC44OTIgMzIuNjQgMjUuODUyIDMyLjY0IDI2Ljg3OCBDIDMyLjY0IDI5LjUyNiA0MC4wMjEgMjkuMjYxIDQwLjAyMSAzNC41OSBDIDQwLjAyMSA0Mi43OTkwMDAwMDAwMDAwMSAyOC43NjcwMDAwMDAwMDAwMDMgMzkuMTU4IDI4Ljc2NzAwMDAwMDAwMDAwMyAzOS4xNTggTCAyOC43NjcwMDAwMDAwMDAwMDMgMzUuMjIgQyAyOC43NjcwMDAwMDAwMDAwMDMgMzUuMjIgMzAuOTE5MDAwMDAwMDAwMDA0IDM2Ljg0MiAzMy41IDM2Ljg0MiBDIDM2LjA4MDk5OTk5OTk5OTk5NiAzNi44NDIgMzUuOTgzIDM1LjE1Mzk5OTk5OTk5OTk5NiAzNS45ODMgMzQuOTIyIEMgMzUuOTgzIDMyLjQ3MyAyOC42Njc5OTk5OTk5OTk5OTYgMzIuNDczIDI4LjY2Nzk5OTk5OTk5OTk5NiAyNy4wNDM5OTk5OTk5OTk5OTcgQyAyOC42Njc5OTk5OTk5OTk5OTYgMTkuNjYyOTk5OTk5OTk5OTk3IDM5LjMyNTk5OTk5OTk5OTk5IDIyLjU3NDk5OTk5OTk5OTk5NiAzOS4zMjU5OTk5OTk5OTk5OSAyMi41NzQ5OTk5OTk5OTk5OTYgTCAzOS4xOTQgMjYuMDg0IHoiCiAgICAgICAgICAgICAgICAgICAgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiAvPgogICAgICAgICAgICA8L2c+CiAgICAgICAgPC9nPgogICAgPC9nPgo8L3N2Zz4=")),
            };

            await dbContext.Technologies.AddRangeAsync(technologies);
            await dbContext.SaveChangesAsync();
        }
    }
    
    private async Task AddWorkModes()
    {
        if (!dbContext.WorkModes.Any())
        {
            var workModes = new List<WorkMode>()
            {
                WorkMode.Create(1, "OnSite"),
                WorkMode.Create(2, "Hybrid"),
                WorkMode.Create(3, "Remote"),
            };

            await dbContext.WorkModes.AddRangeAsync(workModes);
            await dbContext.SaveChangesAsync();
        }
    }
    
    private async Task AddWorkModeTranslations()
    {
        if (!dbContext.WorkModeTranslations.Any())
        {
            var workModeTranslations = new List<WorkModeTranslation>()
            {
                WorkModeTranslation.Create(new Identifier("b792decb-3f83-4f2a-a3a3-839d2b21713c"), 1, LanguageCode.En, "On site"),
                WorkModeTranslation.Create(new Identifier("ffb3b8d2-5a7e-4f1e-9399-52bd465441b5"), 1, LanguageCode.Pl, "Stacjonarnie"),
                WorkModeTranslation.Create(new Identifier("fc99cafe-9774-4e63-809e-9cd842cb8b30"), 2, LanguageCode.En, "Hybrid"),
                WorkModeTranslation.Create(new Identifier("1af8d3f3-bf4a-4307-986a-78241b74629e"), 2, LanguageCode.Pl, "Hybrydowo"),
                WorkModeTranslation.Create(new Identifier("68a39f47-8897-490a-ae3d-8e2d57f1ac27"), 3, LanguageCode.En, "Remote"),
                WorkModeTranslation.Create(new Identifier("8cbb76f4-2c13-476d-8864-0652fedd571d"), 3, LanguageCode.Pl, "Zdalnie"),
            };

            await dbContext.WorkModeTranslations.AddRangeAsync(workModeTranslations);
            await dbContext.SaveChangesAsync();
        }
    }
    
    private async Task AddExperienceLevels()
    {
        if (!dbContext.ExperienceLevels.Any())
        {
            var experienceLevels = new List<ExperienceLevel>()
            {
                ExperienceLevel.Create(1, "Intern"),
                ExperienceLevel.Create(2, "Junior"),
                ExperienceLevel.Create(3, "Regular"),
                ExperienceLevel.Create(4, "Senior"),
                ExperienceLevel.Create(5, "Lead"),
            };

            await dbContext.ExperienceLevels.AddRangeAsync(experienceLevels);
            await dbContext.SaveChangesAsync();
        }
    }
    
    private async Task AddEmploymentTypes()
    {
        if (!dbContext.EmploymentTypes.Any())
        {
            var employmentTypes = new List<EmploymentType>()
            {
                EmploymentType.Create(1, "EmploymentContract"),
                EmploymentType.Create(2, "B2B"),
                EmploymentType.Create(3, "MandateContract"),
                EmploymentType.Create(4, "SpecificTaskContract"),
                EmploymentType.Create(5, "Internship"),
            };

            await dbContext.EmploymentTypes.AddRangeAsync(employmentTypes);
            await dbContext.SaveChangesAsync();
        }
    }

    private static Offer CreateOffer(Identifier id, Title title, Salary salary, Identifier companyId, DateTimeOffset createdAt,
        string[] locationNames, string[] technologyNames, string[] workModesNames, string[] experienceLevelsNames,
        string[] employmentTypeNames, List<Location> locations, List<Technology> technologies, List<WorkMode> workModes,
        List<ExperienceLevel> experienceLevels, List<EmploymentType> employmentTypes)
    {
        var offer = Offer.Create(
            id,
            title,
            salary,
            companyId,
            createdAt
        );

        foreach (var locationName in locationNames)
        {
            var location = locations.SingleOrDefault(l => l.Name == locationName);
            if (location is not null)
            {
                offer.AddLocation(location);
            }
        }
        
        foreach (var technologyName in technologyNames)
        {
            var technology = technologies.SingleOrDefault(l => l.Name == technologyName);
            if (technology is not null)
            {
                offer.AddTechnology(technology);
            }
        }
        
        foreach (var workModeName in workModesNames)
        {
            var workMode = workModes.SingleOrDefault(w => w.Value == workModeName);
            if (workMode is not null)
            {
                offer.AddWorkMode(workMode);
            }
        }
        
        foreach (var experienceLevelName in experienceLevelsNames)
        {
            var experienceLevel = experienceLevels.SingleOrDefault(l => l.Name == experienceLevelName);
            if (experienceLevel is not null)
            {
                offer.AddExperienceLevel(experienceLevel);
            }
        }
        
        foreach (var employmentTypeName in employmentTypeNames)
        {
            var employmentType = employmentTypes.SingleOrDefault(t => t.Name == employmentTypeName);
            if (employmentType is not null)
            {
                offer.AddEmploymentType(employmentType);
            }
        }

        return offer;
    }

    private static string DecodeBase64(string value)
    {
        var bytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(bytes);
    }
}