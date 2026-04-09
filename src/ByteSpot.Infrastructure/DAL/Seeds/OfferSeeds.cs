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
                ],
                "Poszukujemy JavaScript Developera z co najmniej 2-letnim doświadczeniem komercyjnym w tworzeniu aplikacji webowych. Kandydat będzie pracować w zwinnym zespole nad rozwojem aplikacji frontendowych oraz integracji z backendem. Do zadań należeć będzie implementacja interfejsów użytkownika, optymalizacja wydajności renderowania, tworzenie komponentów wielokrotnego użytku oraz udział w procesie testowania. Wymagamy dobrej znajomości JavaScript (ES6+), doświadczenia z frameworkiem React lub Vue, umiejętności pracy z REST API, znajomości HTML5 i CSS3 oraz systemu Git. Doświadczenie z TypeScript, Webpack lub Vite będzie dodatkowym atutem. Oferujemy nowoczesne środowisko pracy, elastyczne godziny, możliwość pracy zdalnej lub hybrydowej, pakiet benefitów oraz jasną ścieżkę awansu w strukturach technicznych firmy."
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
                ],
                "Poszukujemy Java Developera z 2-4 letnim doświadczeniem komercyjnym do pracy nad rozbudowanymi systemami backendowymi. Kandydat będzie częścią zespołu odpowiedzialnego za rozwój i utrzymanie mikroserwisów, integracje zewnętrzne oraz wydajność aplikacji. Do obowiązków należy implementacja i testowanie serwisów REST, praca z bazami danych SQL i NoSQL, udział w dyskusjach architektonicznych i code review. Wymagamy dobrej znajomości Javy 11 lub wyższej, frameworka Spring Boot, doświadczenia z JUnit, Maven lub Gradle oraz umiejętności pracy z systemami kolejkowymi. Znajomość konteneryzacji Docker oraz platform chmurowych (AWS, GCP, Azure) będzie dodatkowym atutem. Oferujemy pełne wsparcie przy wdrożeniu, możliwość pracy hybrydowej lub zdalnej, benefity pracownicze, dofinansowanie szkoleń i pracę przy skalowanych systemach produkcyjnych."
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
                ],
                "Poszukujemy Senior C# Developera z minimum 5 letnim doświadczeniem komercyjnym w ekosystemie .NET. Kandydat obejmie kluczową rolę w zespole inżynierskim, prowadząc projekt techniczny, wspierając kolegów i dbając o jakość wytwarzanego oprogramowania. Do obowiązków należy projektowanie rozwiązań w architekturze mikroserwisowej lub monolitycznej, implementacja w C# i ASP.NET Core, definiowanie dobrych praktyk oraz prowadzenie code review. Wymagamy zaawansowanej znajomości C#, .NET 6 lub nowszego, doświadczenia z Entity Framework, bazami danych SQL Server oraz znajomości wzorców projektowych. Oczekujemy umiejętności pisania testów automatycznych i doświadczenia z Azure lub AWS. Dobra komunikacja i zdolność do pracy z rozproszonymi zespołami są niezbędne. Oferujemy pracę zdalną lub hybrydową, wysokie wynagrodzenie, realny wpływ na architekturę systemu i silną kulturę inżynierską."
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
                ],
                "Zapraszamy Junior Go Developera do dołączenia do naszego zespołu pracującego nad wysokowydajnymi serwisami backendowymi. To idealna oferta dla osoby, która zna podstawy Go i chce rozwijać się w budowaniu systemów rozproszonych. Do obowiązków należeć będzie implementacja mikroserwisów w Go, pisanie testów, udział w code review oraz stopniowe przejmowanie samodzielnych zadań. Wymagamy podstawowej znajomości języka Go, rozumienia koncepcji goroutine i kanałów, umiejętności pracy z Git i podstaw protokołu HTTP. Doświadczenie z frameworkiem Gin, Echo lub doświadczenie z Docker będzie plusem. Oczekujemy ciekawości technicznej, komunikatywności i chęci uczenia się od bardziej doświadczonych kolegów. Oferujemy środowisko sprzyjające eksperymentowaniu, mentoring seniorów, elastyczny czas pracy, dostęp do kursów i konferencji oraz atrakcyjny pakiet startowy."
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
                ],
                "Poszukujemy Python Developera z 2-4 letnim doświadczeniem do pracy nad aplikacjami backendowymi, narzędziami danych lub serwisami API. Kandydat będzie odpowiedzialny za implementację i utrzymanie serwisów backendowych, integrację z zewnętrznymi dostawcami, pisanie testów automatycznych oraz uczestnictwo w przeglądach kodu. Wymagamy dobrej znajomości Pythona 3, doświadczenia z jednym z frameworków (Django, FastAPI lub Flask), umiejętności pracy z relacyjnymi i dokumentowymi bazami danych, znajomości Docker i systemu Git. Doświadczenie z przetwarzaniem danych (Pandas, NumPy) lub uczeniem maszynowym będzie dodatkowym atutem. Cenimy czytelny kod, dokumentowanie pracy i proaktywną komunikację. Oferujemy elastyczny model pracy, możliwość wyboru formy zatrudnienia (UoP lub B2B), prywatną opiekę medyczną i budżet szkoleniowy."
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
                ],
                "Poszukujemy doświadczonego Senior Java Developera do dołączenia do naszego zespołu backendowego. Kandydat powinien posiadać co najmniej 5 lat doświadczenia komercyjnego w Javie oraz udokumentowaną historię pracy z dużymi systemami produkcyjnymi. Do obowiązków należeć będzie projektowanie i implementacja serwisów w oparciu o Spring Boot, optymalizacja zapytań do baz danych, definiowanie standardów kodowania w zespole oraz aktywny udział w procesach rekrutacyjnych. Wymagamy biegłej znajomości Javy 11 lub nowszej, frameworka Spring (Boot, Security, Data), doświadczenia z bazami danych SQL i NoSQL, znajomości Dockera i Kubernetes oraz rozumienia wzorców DDD i CQRS. Doświadczenie z Apache Kafka lub RabbitMQ będzie atutem. Oferujemy pracę nad produktem używanym przez miliony użytkowników, kulturę feedbacku, budżet szkoleniowy i atrakcyjny pakiet wynagrodzenia."
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
                ],
                "Poszukujemy programisty TypeScript do pracy nad nowoczesnymi aplikacjami webowymi i backendowymi. Kandydat powinien posiadać co najmniej 2 lata doświadczenia komercyjnego z TypeScript oraz dobrą znajomość ekosystemu JavaScript. Do obowiązków należeć będzie tworzenie komponentów frontendowych lub serwisów backendowych z użyciem TypeScript, dbanie o jakość typowania i strukturę kodu, udział w code review oraz współpraca z zespołem projektowym i UX. Wymagamy biegłości w TypeScript, znajomości co najmniej jednego frameworka (React, Angular, Vue lub Node.js), zrozumienia wzorców projektowych oraz umiejętności pracy z REST API lub GraphQL. Doświadczenie z testowaniem (Jest, Vitest) będzie dodatkowym atutem. Oferujemy elastyczny model pracy, nowoczesny stack technologiczny oraz realny wpływ na architekturę rozwijanych systemów."
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
                ],
                "Szukamy doświadczonego Senior JavaScript Developera z minimum 5-letnim stażem w tworzeniu aplikacji webowych. Kandydat będzie odpowiedzialny za tworzenie zaawansowanych rozwiązań frontendowych lub fullstackowych, architekturę modułów, mentoring młodszych programistów oraz udział w procesie rekrutacji technicznej. Wymagamy głębokiej znajomości JavaScript (ES6+), biegłości w co najmniej jednym z frameworków React, Vue lub Angular, rozumienia optymalizacji wydajności, zarządzania stanem aplikacji oraz budowania systemów komponentowych. Doświadczenie z TypeScript, znajomość narzędzi bundlujących (Webpack, Vite) oraz CI/CD będzie mile widziane. Oczekujemy samodzielności, umiejętności prowadzenia dyskusji technicznych oraz dobrego poziomu angielskiego. Oferujemy wysokie wynagrodzenie, elastyczną formę współpracy (B2B lub UoP), prywatną opiekę zdrowotną oraz dofinansowanie konferencji branżowych."
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
                ],
                "Jesteśmy w trakcie rozbudowy naszego działu produktowego i poszukujemy doświadczonego Senior C# Developera. Oczekujemy od kandydata co najmniej 5 lat pracy z C# i platformą .NET oraz głębokiej znajomości zasad SOLID, wzorców projektowych i najlepszych praktyk inżynierskich. Do zadań należeć będzie implementacja złożonych funkcjonalności biznesowych, współpraca z analitykami i product ownerami, prowadzenie przeglądu kodu oraz aktywne uczestnictwo w planowaniu architektury. Wymagamy biegłości w ASP.NET Core, znajomości platform chmurowych, doświadczenia z Docker i Kubernetes oraz umiejętności pracy z bazami danych SQL i NoSQL. Kandydat powinien wykazywać proaktywną postawę i inicjatywę. Oferujemy możliwość pracy w pełni zdalnej, prywatną opiekę medyczną, pakiet benefitów kafeteryjnych, dofinansowanie sprzętu oraz atmosferę opartą na zaufaniu i odpowiedzialności."
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
                ],
                "Poszukujemy Lead Python Developera, który obejmie techniczną odpowiedzialność za jeden z naszych kluczowych produktów. Kandydat powinien posiadać minimum 6 lat doświadczenia z Pythonem oraz wcześniejsze doświadczenie w roli tech leada lub seniora z aspiracjami przywódczymi. Do obowiązków należeć będzie prowadzenie zespołu developerskiego, definiowanie standardów technicznych, architektura systemów backendowych, mentoring i code review. Wymagamy zaawansowanej znajomości Pythona, frameworków FastAPI lub Django, baz danych SQL i NoSQL, doświadczenia z systemami kolejkowymi (Kafka, RabbitMQ) oraz infrastrukturą chmurową. Oczekujemy umiejętności zarządzania zadaniami zespołu, prowadzenia rozmów 1:1 oraz współpracy z działem produktu. Oferujemy stanowisko z realnym wpływem na kierunek techniczny firmy, pakiet akcji lub udziałów, wysoki budżet szkoleniowy i współpracę z najlepszymi inżynierami."
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
                ],
                "Oferujemy stanowisko Junior C# Developer dla osoby rozpoczynającej karierę w programowaniu lub posiadającej pierwsze doświadczenia komercyjne. Szukamy zmotywowanego kandydata, który chce rozwijać się w ekosystemie .NET. Do obowiązków należeć będzie tworzenie i utrzymanie aplikacji w języku C# z wykorzystaniem platformy .NET, udział w codziennych spotkaniach zespołu, pisanie testów jednostkowych oraz dokumentowanie kodu. Wymagamy podstawowej znajomości języka C# i frameworka .NET, rozumienia paradygmatu obiektowego, znajomości relacyjnych baz danych oraz podstaw pracy z Git. Mile widziane są doświadczenia z ASP.NET Core lub Entity Framework. Oferujemy mentoring ze strony doświadczonych programistów, jasną ścieżkę kariery, dostęp do platform edukacyjnych oraz przyjazną atmosferę pracy sprzyjającą nauce."
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
                ],
                "Poszukujemy Fullstack Developera z 2-4 letnim doświadczeniem, który chce pracować nad kompletem produktu od frontendu do backendu. Kandydat będzie odpowiedzialny za implementację nowych funkcjonalności, utrzymanie istniejących modułów, integrację z zewnętrznymi API oraz dbanie o jakość i testowalność kodu. Wymagamy dobrej znajomości JavaScript lub TypeScript po stronie frontendu (React, Vue lub Angular) oraz backendu (Node.js, Python lub Java), umiejętności projektowania i konsumowania REST API, znajomości relacyjnych baz danych oraz podstaw Docker i Git. Mile widziane jest doświadczenie z platformami chmurowymi i narzędziami CI/CD. Oferujemy pracę w niewielkim, zgranym zespole, realny wpływ na produkt, elastyczne godziny, nowoczesny stack technologiczny, opiekę medyczną i dodatkowe benefity."
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
                ],
                "Szukamy doświadczonego Senior Rust Developera, który dołączy do naszego zespołu i weźmie aktywny udział w tworzeniu zaawansowanych systemów backendowych. Oczekujemy minimum 5 lat doświadczenia w programowaniu, w tym co najmniej 3 lata pracy z językiem Rust w środowisku produkcyjnym. Kandydat powinien doskonale rozumieć koncepcje ownership, borrowing i lifetimes, posiadać praktyczną znajomość frameworków asynchronicznych (Tokio, async-std) oraz doświadczenie w projektowaniu skalowalnych architektur. Do obowiązków będzie należeć prowadzenie zespołu technicznego, mentoring młodszych programistów, udział w planowaniu sprintów oraz podejmowanie kluczowych decyzji architektonicznych. Wymagana jest także umiejętność integracji z bazami danych, znajomość konteneryzacji (Docker, Kubernetes) oraz doświadczenie z CI/CD. Oferujemy konkurencyjne wynagrodzenie, prywatną opiekę medyczną, budżet szkoleniowy i możliwość realnego wpływu na kształt produktu."
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
                ],
                "Poszukujemy Mobile Developera do tworzenia nowoczesnych aplikacji mobilnych na platformy iOS i Android. Kandydat będzie odpowiedzialny za projektowanie i implementację funkcjonalności aplikacji mobilnych, współpracę z zespołem backendowym przy integracji API, a także optymalizację działania aplikacji i dbanie o jakość kodu. Wymagamy co najmniej 2 lat doświadczenia w tworzeniu aplikacji mobilnych, znajomości React Native, Flutter, Swift lub Kotlin. Oczekujemy rozumienia cyklu życia aplikacji mobilnych, doświadczenia z publikacją w App Store i Google Play oraz znajomości REST API. Mile widziane jest doświadczenie z push notifications, animacjami i obsługą urządzeń z różnymi rozdzielczościami ekranu. Oferujemy pracę przy innowacyjnych projektach, nowoczesny sprzęt, elastyczny model pracy oraz możliwość udziału w konferencjach mobilnych."
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
                ],
                "Poszukujemy doświadczonego Senior C/C++ Developera specjalizującego się w programowaniu systemowym, wbudowanym lub niskopoziomowym. Kandydat powinien posiadać minimum 5 lat komercyjnego doświadczenia z C lub C++ oraz udokumentowaną historię pracy w wymagających środowiskach. Do obowiązków należy tworzenie i optymalizacja kodu niskopoziomowego, analiza wydajnościowa, praca z pamięcią i zarządzanie zasobami systemowymi, a także współpraca z zespołami firmware i hardware. Wymagamy zaawansowanej znajomości C++17 lub nowszego, doświadczenia z wielowątkowością i synchronizacją, znajomości narzędzi do profilowania i debugowania (Valgrind, GDB) oraz systemów budowania (CMake). Doświadczenie z systemami real-time lub wbudowanymi (RTOS, ARM) będzie mile widziane. Oferujemy udział w innowacyjnych projektach technologicznych, elastyczne warunki zatrudnienia, wysokie wynagrodzenie i budżet na sprzęt."
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
                ],
                "Szukamy Junior JavaScript Developera, który stawia pierwsze kroki w komercyjnym programowaniu i chce rozwijać się w środowisku nowoczesnych aplikacji webowych. Do zadań na tym stanowisku należeć będzie implementacja interfejsów użytkownika, poprawki błędów, udział w code review jako obserwator oraz stopniowe przejmowanie samodzielnych zadań pod okiem seniora. Wymagamy znajomości podstaw JavaScript, HTML i CSS, rozumienia DOM oraz podstawowej orientacji w frameworkach takich jak React lub Vue. Znajomość systemu Git, umiejętność komunikacji w zespole i chęć uczenia się są dla nas równie ważne jak wiedza techniczna. Oferujemy program wdrożeniowy, regularne sesje 1:1 z mentorem, dostęp do kursów online oraz realną możliwość awansu wraz ze wzrostem kompetencji."
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
                ],
                "Poszukujemy doświadczonego programisty Rust do naszego zespołu inżynierskiego. Kandydat będzie odpowiedzialny za projektowanie i implementację wydajnych, bezpiecznych aplikacji backendowych oraz systemowych. Do głównych obowiązków należy pisanie czystego i testowalnego kodu w języku Rust, udział w przeglądach kodu, projektowanie architektury mikroserwisów oraz optymalizacja wydajności istniejących rozwiązań. Wymagamy co najmniej 2 lat komercyjnego doświadczenia z językiem Rust, znajomości bibliotek takich jak Tokio, Actix lub Axum, wiedzy na temat programowania asynchronicznego oraz znajomości systemów kontroli wersji, w szczególności Git. Dodatkowym atutem będzie doświadczenie z WebAssembly lub systemami wbudowanymi. Oferujemy pracę w dynamicznym środowisku, elastyczne godziny pracy, możliwość pracy zdalnej oraz atrakcyjne wynagrodzenie dostosowane do poziomu umiejętności kandydata."
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
                ],
                "Poszukujemy Senior Fullstack Developera do budowania produktów w nowoczesnym stacku technologicznym. Kandydat będzie odpowiedzialny zarówno za warstwę frontendową, jak i backendową aplikacji, uczestniczyć będzie w projektowaniu architektury, prowadzeniu code review i wsparciu młodszych kolegów. Wymagamy minimum 5 lat doświadczenia w tworzeniu aplikacji webowych, biegłości w React lub Vue (frontend) oraz Node.js, Python lub Java (backend), a także znajomości relacyjnych i nierelacyjnych baz danych. Niezbędna jest umiejętność pracy z REST API lub GraphQL, konteneryzacją oraz doświadczenie z CI/CD. Oczekujemy samodzielności, umiejętności oceny trade-offów technicznych i dobrego poziomu języka angielskiego. Oferujemy pracę przy ambitnych produktach, elastyczny grafik, nowoczesne narzędzia, prywatną opiekę zdrowotną, dofinansowanie nauki oraz integracje zespołowe."
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
                ],
                "Poszukujemy Junior C# Developera chętnego do nauki i rozwijania swoich umiejętności w środowisku .NET. Na tym stanowisku będziesz pracować w bliskim kontakcie z doświadczonymi programistami, stopniowo przejmując coraz bardziej złożone zadania. Do codziennych obowiązków należeć będzie implementacja funkcjonalności w C#, udział w testowaniu aplikacji, analiza i naprawa błędów oraz uczestnictwo w spotkaniach zespołu. Wymagamy podstawowej znajomości C# i platformy .NET, zrozumienia programowania obiektowego oraz umiejętności pracy z Git. Doświadczenie z bazami danych SQL oraz ASP.NET będzie dodatkowym atutem. Szanujemy chęć do nauki ponad wszystko i zapewniamy środowisko, w którym pytania są mile widziane. Oferujemy opiekę medyczną, kartę sportową, elastyczne godziny i wsparcie w zdobywaniu certyfikatów branżowych."
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
                ],
                "Poszukujemy ambitnego Junior Python Developera do naszego rosnącego zespołu backendowego. Stanowisko skierowane jest do osób z pierwszymi doświadczeniami komercyjnymi lub absolwentów kierunków technicznych, którzy chcą rozwijać się w programowaniu w Pythonie. Do obowiązków należeć będzie implementacja nowych funkcjonalności, poprawianie błędów, pisanie testów jednostkowych i współpraca przy integracji z zewnętrznymi API. Wymagamy znajomości podstaw Pythona, zrozumienia programowania obiektowego i funkcyjnego, umiejętności pracy z Git oraz podstaw obsługi baz danych SQL. Znajomość frameworków Django lub Flask będzie dodatkowym atutem. Chęć do nauki i otwartość na feedback są dla nas tak samo ważne jak umiejętności techniczne. Oferujemy program mentorski, jasny plan rozwoju, elastyczne warunki pracy, dofinansowanie szkoleń i certyfikatów."
            ),
        ];

        return offers.AsReadOnly();
    }

    private Offer CreateOffer(Identifier id, Title title, Identifier companyId, DateTimeOffset createdAt,
        DateTimeOffset expiresAt, string[] locations, string[] technologies, string[] workModes,
        string[] experienceLevels, string[] employmentTypes, Salary[] salaries, string description)
    {
        var offer = Offer.Create(
            id,
            title,
            companyId,
            createdAt,
            expiresAt,
            description
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