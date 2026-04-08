using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Infrastructure.DAL.Database;

namespace ByteSpot.Infrastructure.DAL.Seeds;

class OfferSeeds
{
    private readonly ByteSpotDbContext _dbContext;
    private readonly IReadOnlyCollection<Company> _companies;
    private readonly IReadOnlyCollection<Location> _locations;
    private readonly IReadOnlyCollection<Technology> _technologies;
    private readonly IReadOnlyCollection<WorkMode> _workModes;
    private readonly IReadOnlyCollection<ExperienceLevel> _experienceLevels;
    private readonly IReadOnlyCollection<EmploymentType> _employmentTypes;
    public readonly IReadOnlyCollection<Offer> Offers;

    public OfferSeeds(
        ByteSpotDbContext dbContext,
        IReadOnlyCollection<Company> companies,
        IReadOnlyCollection<Location> locations,
        IReadOnlyCollection<Technology> technologies,
        IReadOnlyCollection<WorkMode> workModes,
        IReadOnlyCollection<ExperienceLevel> experienceLevels,
        IReadOnlyCollection<EmploymentType> employmentTypes)
    {
        _dbContext = dbContext;
        _companies = companies;
        _locations = locations;
        _technologies = technologies;
        _workModes = workModes;
        _experienceLevels = experienceLevels;
        _employmentTypes = employmentTypes;

        Offers = InitOffers();
    }

    public async Task InitAsync()
    {
        if (!_dbContext.Offers.Any())
        {
            await _dbContext.AddRangeAsync(Offers);
            await _dbContext.SaveChangesAsync();
        }
    }

    private IReadOnlyCollection<Offer> InitOffers()
    {
        var now = DateTime.UtcNow;
        
        List<Offer> offers =
        [
            CreateOffer(
                new Identifier("cd11aea2-9a6c-4462-b16b-570d75247129"),
                "JavaScript Developer",
                _companies.ElementAt(0).Id,
                now.AddMinutes(1),
                now.AddDays(30).AddMinutes(1),
                ["Warszawa", "Bydgoszcz"],
                ["JavaScript", "TypeScript"],
                ["Remote", "Hybrid"],
                ["Regular"],
                ["EmploymentContract", "B2B"],
                [
                    Salary.Create(
                        new Identifier("394a1569-0a83-47cb-b80b-12735bb6c95b"),
                        new Identifier("cd11aea2-9a6c-4462-b16b-570d75247129"),
                        1,
                        SalaryType.GROSS,
                        11_000,
                        16_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("e6b9f258-9aaa-4f74-bcbc-8bcda74b87d5"),
                        new Identifier("cd11aea2-9a6c-4462-b16b-570d75247129"),
                        2,
                        SalaryType.NET,
                        12_000,
                        18_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("df08859f-df88-45bb-b59a-cd856e578f16"),
                "Java Developer",
                _companies.ElementAt(1).Id,
                now.AddMinutes(2),
                now.AddDays(30).AddMinutes(2),
                ["Wrocław"],
                ["Java", "Mobile"],
                ["Hybrid", "OnSite"],
                ["Regular", "Senior"],
                ["B2B", "MandateContract"],
                [
                    Salary.Create(
                        new Identifier("972443b8-cb5c-477d-b0af-645e0ee1507a"),
                        new Identifier("cd11aea2-9a6c-4462-b16b-570d75247129"),
                        1,
                        SalaryType.NET,
                        90,
                        100,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.HOUR
                    ),
                    Salary.Create(
                        new Identifier("9c48f843-7079-4735-b75d-4b0aed4e8295"),
                        new Identifier("cd11aea2-9a6c-4462-b16b-570d75247129"),
                        3,
                        SalaryType.GROSS,
                        80,
                        90,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.HOUR
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("8cae5d4f-eb4a-4a15-b504-6ee321ee1534"),
                "Senior C# Developer",
                _companies.ElementAt(2).Id,
                now.AddMinutes(3),
                now.AddDays(30).AddMinutes(3),
                ["Kraków", "Wrocław", "Warszawa", "Poznań", "Gdańsk", "Katowice", "Łódź"],
                ["C#", "SQL", "Azure"],
                ["Remote"],
                ["Senior"],
                ["B2B"],
                [
                    Salary.Create(
                        new Identifier("53dc3b46-7549-47f8-afd8-ba167e3aa5d4"),
                        new Identifier("8cae5d4f-eb4a-4a15-b504-6ee321ee1534"),
                        2,
                        SalaryType.NET,
                        null,
                        null,
                        8_000,
                        CurrencyCode.USD,
                        BillingUnit.MONTH   
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("db657ff0-115b-484b-b19a-51704e8dbc93"),
                "Junior Go Developer",
                _companies.ElementAt(3).Id,
                now.AddMinutes(4),
                now.AddDays(30).AddMinutes(4),
                ["Kraków"],
                ["Go", "Python"],
                ["OnSite"],
                ["Intern", "Junior"],
                ["MandateContract", "SpecificTaskContract", "Internship"],
                [
                    Salary.Create(
                        new Identifier("645f6e01-892f-4de8-bb03-e683569f52cb"),
                        new Identifier("db657ff0-115b-484b-b19a-51704e8dbc93"),
                        3,
                        SalaryType.GROSS,
                        8_000,
                        10_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("a46f1a94-2c3d-42d9-8495-5c72d8101160"),
                        new Identifier("db657ff0-115b-484b-b19a-51704e8dbc93"),
                        4,
                        SalaryType.NET,
                        8_500,
                        10_500,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("1506b059-03ed-47d3-afb4-fd36ab43da04"),
                        new Identifier("db657ff0-115b-484b-b19a-51704e8dbc93"),
                        5,
                        SalaryType.GROSS,
                        8_000,
                        10_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("f46fc3a8-be21-4451-91e4-45015f71e4df"),
                "Python Developer",
                _companies.ElementAt(4).Id,
                now.AddMinutes(5),
                now.AddDays(30).AddMinutes(5),
                ["Toruń", "Poznań"],
                ["SQL", "Python"],
                ["Hybrid"],
                ["Regular", "Senior"],
                ["EmploymentContract"],
                [
                    Salary.Create(
                        new Identifier("fdc967e9-c452-4b2c-9076-3aa8140d5d3d"),
                        new Identifier("f46fc3a8-be21-4451-91e4-45015f71e4df"),
                        1,
                        SalaryType.GROSS,
                        15_000,
                        18_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("87ab8cad-f4a7-4e7e-a174-b8618c93ecf5"),
                "Senior Java Developer",
                _companies.ElementAt(5).Id,
                now.AddMinutes(6),
                now.AddDays(30).AddMinutes(6),
                ["Kraków", "Katowice", "Gliwice"],
                ["AWS", "Java"],
                ["Remote", "Hybrid"],
                ["Senior"],
                ["B2B", "SpecificTaskContract"],
                [
                    Salary.Create(
                        new Identifier("5aaca968-20a2-4a3d-a026-157fdddf19ac"),
                        new Identifier("87ab8cad-f4a7-4e7e-a174-b8618c93ecf5"),
                        2,
                        SalaryType.NET,
                        210,
                        215,
                        null,
                        CurrencyCode.EUR,
                        BillingUnit.DAY
                    ),
                    Salary.Create(
                        new Identifier("75c3d8bd-0f97-41f1-acc6-033137e6a659"),
                        new Identifier("87ab8cad-f4a7-4e7e-a174-b8618c93ecf5"),
                        4,
                        SalaryType.NET,
                        200,
                        205,
                        null,
                        CurrencyCode.EUR,
                        BillingUnit.DAY
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("44c4509c-d56f-422c-b601-35d5c69283e7"),
                "TypeScript Developer",
                _companies.ElementAt(6).Id,
                now.AddMinutes(7),
                now.AddDays(30).AddMinutes(7),
                ["Białystok"],
                ["TypeScript", "Python"],
                ["Remote"],
                ["Regular"],
                ["EmploymentContract"],
                [
                    Salary.Create(
                        new Identifier("e2f4d510-54f7-4e69-a1e4-0edcdf38739a"),
                        new Identifier("44c4509c-d56f-422c-b601-35d5c69283e7"),
                        1,
                        SalaryType.GROSS,
                        12_000,
                        15_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("6a37b912-d8f6-488c-aa6d-c1c7a5bd3026"),
                "Senior JavaScript Developer",
                _companies.ElementAt(0).Id,
                now.AddMinutes(8),
                now.AddDays(30).AddMinutes(8),
                ["Warszawa", "Kraków"],
                ["TypeScript", "SQL", "PHP"],
                ["Remote"],
                ["Senior"],
                ["EmploymentContract", "B2B"],
                [
                    Salary.Create(
                        new Identifier("e70220b3-4c7c-4b83-9858-35a3225e2452"),
                        new Identifier("6a37b912-d8f6-488c-aa6d-c1c7a5bd3026"),
                        1,
                        SalaryType.GROSS,
                        17_000,
                        19_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("f230af7b-c8c3-40d8-a0f9-8ccad9d6bbc5"),
                        new Identifier("6a37b912-d8f6-488c-aa6d-c1c7a5bd3026"),
                        2,
                        SalaryType.NET,
                        120,
                        150,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.HOUR
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("923c67af-ec64-4d20-a0b7-ba423d2faee5"),
                "Senior C# Developer",
                _companies.ElementAt(1).Id,
                now.AddMinutes(9),
                now.AddDays(30).AddMinutes(9),
                ["Zielona Góra", "Gorzów Wielkopolski"],
                ["C#", "Azure"],
                ["Remote", "Hybrid", "OnSite"],
                ["Senior"],
                ["B2B", "MandateContract"],
                [
                    Salary.Create(
                        new Identifier("9f6057a4-6bc3-40bd-aa66-05f617a9467d"),
                        new Identifier("923c67af-ec64-4d20-a0b7-ba423d2faee5"),
                        2,
                        SalaryType.NET,
                        15_000,
                        17_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("ccc0fe73-84dd-4b41-b4d0-2b2680a59517"),
                        new Identifier("923c67af-ec64-4d20-a0b7-ba423d2faee5"),
                        3,
                        SalaryType.GROSS,
                        14_000,
                        16_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("9db0fdfd-d032-4b78-b850-75c7d90a8468"),
                "Lead Python Developer",
                _companies.ElementAt(2).Id,
                now.AddMinutes(10),
                now.AddDays(30).AddMinutes(10),
                ["Bydgoszcz", "Toruń", "Szczecin"],
                ["AWS", "Python"],
                ["Remote"],
                ["Lead"],
                ["EmploymentContract", "B2B"],
                [
                    Salary.Create(
                        new Identifier("a21ebb57-408d-43b2-80ab-09402dcaea1c"),
                        new Identifier("9db0fdfd-d032-4b78-b850-75c7d90a8468"),
                        1,
                        SalaryType.GROSS,
                        19_000,
                        22_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("16baab0d-d10c-4302-8652-e867493defd2"),
                        new Identifier("9db0fdfd-d032-4b78-b850-75c7d90a8468"),
                        2,
                        SalaryType.NET,
                        21_000,
                        24_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("34744eb2-da49-4314-a49d-a42b9f0efbea"),
                "Junior C# Developer",
                _companies.ElementAt(3).Id,
                now.AddMinutes(11),
                now.AddDays(30).AddMinutes(11),
                ["Kielce", "Łódź"],
                ["C#", "SQL"],
                ["OnSite"],
                ["Junior"],
                ["Internship"],
                [
                    Salary.Create(
                        new Identifier("feec6afa-d341-4af8-94c8-fb061d2b2548"),
                        new Identifier("34744eb2-da49-4314-a49d-a42b9f0efbea"),
                        5,
                        SalaryType.GROSS,
                        null,
                        null,
                        8_000,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("f6f910b8-6667-425d-95e9-74810ff62b6e"),
                "Fullstack Developer",
                _companies.ElementAt(4).Id,
                now.AddMinutes(12),
                now.AddDays(30).AddMinutes(12),
                ["Gorzów Wielkopolski", "Zielona Góra"],
                ["AWS", "Azure", "TypeScript", "JavaScript", "Python", "SQL"],
                ["Hybrid"],
                ["Regular", "Senior", "Lead"],
                ["EmploymentContract", "B2B"],
                [
                    Salary.Create(
                        new Identifier("6604362d-142d-444d-8af5-12a439f41311"),
                        new Identifier("f6f910b8-6667-425d-95e9-74810ff62b6e"),
                        1,
                        SalaryType.GROSS,
                        17_000,
                        19_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("52768148-5d89-4e42-b39b-8635c4d33b5d"),
                        new Identifier("f6f910b8-6667-425d-95e9-74810ff62b6e"),
                        2,
                        SalaryType.NET,
                        19_000,
                        22_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("1a5a4855-247d-49c6-9b43-b488317881ca"),
                "Senior Rust Developer",
                _companies.ElementAt(5).Id,
                now.AddMinutes(13),
                now.AddDays(30).AddMinutes(13),
                ["Wrocław"],
                ["Rust", "C"],
                ["Remote"],
                ["Senior", "Lead"],
                ["B2B"],
                [
                    Salary.Create(
                        new Identifier("f581a211-80d1-4b27-8be5-a5f78ed1d0bf"),
                        new Identifier("1a5a4855-247d-49c6-9b43-b488317881ca"),
                        2,
                        SalaryType.NET,
                        21_000,
                        25_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("89ea7c6e-e49a-48d5-8439-03e21263b66e"),
                "Mobile Developer",
                _companies.ElementAt(6).Id,
                now.AddMinutes(14),
                now.AddDays(30).AddMinutes(14),
                ["Rzeszów", "Lublin"],
                ["Mobile"],
                ["Remote", "Hybrid"],
                ["Regular", "Senior"],
                ["MandateContract", "SpecificTaskContract"],
                [
                    Salary.Create(
                        new Identifier("2f4d926d-e8e8-4b68-af40-87840a918775"),
                        new Identifier("89ea7c6e-e49a-48d5-8439-03e21263b66e"),
                        3,
                        SalaryType.GROSS,
                        16_000,
                        18_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("d40cc6e7-39c9-4dc5-9483-686c98b6a1e7"),
                        new Identifier("89ea7c6e-e49a-48d5-8439-03e21263b66e"),
                        4,
                        SalaryType.NET,
                        16_500,
                        18_500,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("ed31f986-09c2-4c9e-95ab-ea43e43e16e9"),
                "Senior C/C++ Developer",
                _companies.ElementAt(0).Id,
                now.AddMinutes(15),
                now.AddDays(30).AddMinutes(15),
                ["Gdańsk", "Gdynia", "Sopot"],
                ["C", "C++", "C#"],
                ["Hybrid", "OnSite"],
                ["Senior"],
                ["EmploymentContract"],
                [
                    Salary.Create(
                        new Identifier("3fdaab63-3484-4e5b-b595-1ee148973781"),
                        new Identifier("ed31f986-09c2-4c9e-95ab-ea43e43e16e9"),
                        1,
                        SalaryType.GROSS,
                        null,
                        null,
                        17_500,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("76dbce69-81ad-4ccb-befa-2707d94e25b5"),
                "Junior JavaScript Developer",
                _companies.ElementAt(1).Id,
                now.AddMinutes(16),
                now.AddDays(30).AddMinutes(16),
                ["Warszawa", "Kraków", "Wrocław", "Łódź", "Poznań", "Lublin"],
                ["JavaScript"],
                ["OnSite"],
                ["Intern"],
                ["SpecificTaskContract", "Internship"],
                [
                    Salary.Create(
                        new Identifier("54dfa3f7-bfd1-43c4-9170-6c1ce7ca8b59"),
                        new Identifier("76dbce69-81ad-4ccb-befa-2707d94e25b5"),
                        4,
                        SalaryType.NET,
                        null,
                        null,
                        8_000,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("b2d9d183-8eaf-446a-badf-2a9873cb9fee"),
                        new Identifier("76dbce69-81ad-4ccb-befa-2707d94e25b5"),
                        5,
                        SalaryType.GROSS,
                        null,
                        null,
                        8_500,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("0e278e45-3b6c-42b9-90ce-e902034cbf18"),
                "Rust Developer",
                _companies.ElementAt(2).Id,
                now.AddMinutes(17),
                now.AddDays(30).AddMinutes(17),
                ["Warszawa", "Kraków"],
                ["Rust", "SQL"],
                ["Remote"],
                ["Regular"],
                ["B2B"],
                [
                    Salary.Create(
                        new Identifier("ee44212b-ea1e-45c8-bb75-7a0e5fe95b21"),
                        new Identifier("0e278e45-3b6c-42b9-90ce-e902034cbf18"),
                        2,
                        SalaryType.NET,
                        18_000,
                        21_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("c74f934f-50e2-4655-9a37-2281cfddb043"),
                "Senior Fullstack Developer",
                _companies.ElementAt(3).Id,
                now.AddMinutes(18),
                now.AddDays(30).AddMinutes(18),
                ["Katowice", "Gliwice"],
                ["TypeScript", "Python", "SQL"],
                ["Remote", "Hybrid"],
                ["Regular", "Senior", "Lead"],
                ["EmploymentContract", "B2B", "MandateContract", "SpecificTaskContract"],
                [
                    Salary.Create(
                        new Identifier("c65fe9c3-d9d7-4a17-9b9a-5a26088b589f"),
                        new Identifier("c74f934f-50e2-4655-9a37-2281cfddb043"),
                        1,
                        SalaryType.GROSS,
                        null,
                        null,
                        17_000,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("505c8c14-e4f9-41e5-b8d0-6ff0b42d5713"),
                        new Identifier("c74f934f-50e2-4655-9a37-2281cfddb043"),
                        2,
                        SalaryType.NET,
                        null,
                        null,
                        19_000,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("9b127dd4-a859-4a85-a262-52c6cb0cb5cf"),
                        new Identifier("c74f934f-50e2-4655-9a37-2281cfddb043"),
                        3,
                        SalaryType.GROSS,
                        null,
                        null,
                        17_500,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("900c1b73-00f9-4ab7-85ce-7f7a73f56900"),
                        new Identifier("c74f934f-50e2-4655-9a37-2281cfddb043"),
                        4,
                        SalaryType.NET,
                        null,
                        null,
                        18_000,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("7ee41092-960f-4b93-8a8d-27fb32e30855"),
                "Junior C# Developer",
                _companies.ElementAt(4).Id,
                now.AddMinutes(19),
                now.AddDays(30).AddMinutes(19),
                ["Kraków", "Wrocław"],
                ["Azure", "C#"],
                ["Hybrid", "OnSite"],
                ["Intern", "Junior"],
                ["EmploymentContract", "Internship"],
                [
                    Salary.Create(
                        new Identifier("224dae88-c0b8-403b-880d-66358a753745"),
                        new Identifier("7ee41092-960f-4b93-8a8d-27fb32e30855"),
                        1,
                        SalaryType.GROSS,
                        9_000,
                        10_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                    Salary.Create(
                        new Identifier("d74f3a69-438e-451e-a211-1174abbb12a2"),
                        new Identifier("7ee41092-960f-4b93-8a8d-27fb32e30855"),
                        5,
                        SalaryType.GROSS,
                        10_000,
                        11_000,
                        null,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
            CreateOffer(
                new Identifier("d36d28ac-1ec1-4e4a-bc31-1d353a3db78e"),
                "Junior Python Developer",
                _companies.ElementAt(5).Id,
                now.AddMinutes(20),
                now.AddDays(30).AddMinutes(20),
                ["Warszawa", "Gdańsk"],
                ["SQL", "Python", "JavaScript"],
                ["OnSite"],
                ["Junior"],
                ["EmploymentContract"],
                [
                    Salary.Create(
                        new Identifier("931a8394-470b-4f5e-966f-3136e8782f11"),
                        new Identifier("d36d28ac-1ec1-4e4a-bc31-1d353a3db78e"),
                        1,
                        SalaryType.GROSS,
                        null,
                        null,
                        7_000,
                        CurrencyCode.PLN,
                        BillingUnit.MONTH
                    ),
                ]
            ),
        ];

        return offers.AsReadOnly();
    }

    private Offer CreateOffer(Identifier id, Title title, Identifier companyId, DateTimeOffset createdAt,
        DateTimeOffset expiresAt, string[] locations, string[] technologies, string[] workModes,
        string[] experienceLevels, string[] employmentTypes, Salary[] salaries = default)
    {
        var offer = Offer.Create(
            id,
            title,
            companyId,
            createdAt,
            expiresAt
        );

        foreach (var salary in salaries)
        {
            offer.AddSalary(salary);
        }

        foreach (var location in locations)
        {
          offer.AddLocation(_locations.Single(l => l.Name == location));
        }

        foreach (var technology in technologies)
        {
            offer.AddTechnology(_technologies.Single(t => t.Name == technology));
        }

        foreach (var workMode in workModes)
        {
            offer.AddWorkMode(_workModes.Single(w => w.Value == workMode));
        }

        foreach (var experienceLevel in experienceLevels)
        {
            offer.AddExperienceLevel(_experienceLevels.Single(l => l.Value == experienceLevel));
        }

        foreach (var employmentType in employmentTypes)
        {
            offer.AddEmploymentType(_employmentTypes.Single(t => t.Value == employmentType));
        }

        return offer;
    }
}