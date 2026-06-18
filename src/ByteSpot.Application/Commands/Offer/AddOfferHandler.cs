using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Entities;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Application.Commands.Offer;

public class AddOfferHandler : ICommandHandler<AddOfferCommand>
{
    private readonly ILocationRepository _locationRepository;
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IWorkModeRepository _workModeRepository;
    private readonly IExperienceLevelRepository _experienceLevelRepository;
    private readonly IEmploymentTypeRepository _employmentTypeRepository;
    private readonly IOfferRepository _offerRepository;

    public AddOfferHandler(
        ILocationRepository locationRepository,
        ITechnologyRepository technologyRepository,
        IWorkModeRepository workModeRepository,
        IExperienceLevelRepository experienceLevelRepository,
        IEmploymentTypeRepository employmentTypeRepository,
        IOfferRepository offerRepository
        )
    {
        _locationRepository = locationRepository;
        _technologyRepository = technologyRepository;
        _workModeRepository = workModeRepository;
        _experienceLevelRepository = experienceLevelRepository;
        _employmentTypeRepository = employmentTypeRepository;
        _offerRepository = offerRepository;
    }
    
    public async Task HandleAsync(AddOfferCommand command)
    {
        var workModeIds = command.WorkModes.Distinct().Select(workMode => workMode.ToString()).ToList();
        var workModes = await GetWorkModesAsync(workModeIds);
        
        var locationIds = command.Locations.Distinct().Select(location => new Identifier(location)).ToList();
        var locations = await GetLocationsAsync(locationIds);
        
        var experienceLevelIds = command.ExperienceLevels.Distinct().Select(experienceLevel => experienceLevel.ToString()).ToList();
        var experienceLevels = await GetExperienceLevelsAsync(experienceLevelIds);
        
        var technologyIds = command.Technologies.Distinct().Select(technology => new Identifier(technology)).ToList();
        var technologies = await GetTechnologiesAsync(technologyIds);

        var employmentTypeIds = command.Contracts.Select(contract => contract.EmploymentTypeId.ToString()).Distinct().ToList();
        var  employmentTypes = await GetEmploymentTypesAsync(employmentTypeIds);
        
        var salaries = GetSalaries(command.Contracts, command.Id);

        var createdAt = DateTimeOffset.UtcNow;
        
        var expiresAt = DateTimeOffset.UtcNow.AddDays(30);
        
        var title = new Title(command.Title);
        var description = new Description(command.Description);
        
        //TODO Read base on user
        var companyId = Identifier.Create("893ce20d-329c-4417-b68f-54a01572ab2d");

        var offer = Domain.Entities.Offer.Create(
            command.Id,
            title,
            companyId,
            createdAt,
            expiresAt,
            description
        );
        
        offer.AddWorkModes(workModes);
        offer.AddLocations(locations);
        offer.AddExperienceLevels(experienceLevels);
        offer.AddTechnologies(technologies);
        offer.AddEmploymentTypes(employmentTypes);
        offer.AddSalaries(salaries);
        
        await _offerRepository.AddAsync(offer);
    }

    private async Task<IEnumerable<Domain.Entities.WorkMode>> GetWorkModesAsync(List<string> workModeIds)
    {
        var existingWorkModes = (await _workModeRepository.GetByIdsAsync(workModeIds)).ToList();

        if (existingWorkModes.Count < 1)
        {
            throw new InvalidOperationException(
                $"Zbyt malo");
        }
        
        var existingWorkModeIds = existingWorkModes.Select(workMode => workMode.Id.ToString());
        var missingWorkModeIds = workModeIds.Except(existingWorkModeIds).ToList();

        if (missingWorkModeIds.Count > 0)
        {
            throw new InvalidOperationException(
                $"Nie znaleziono work Mode o ID: {string.Join(", ", missingWorkModeIds)}");
        }

        return existingWorkModes;
    }
    
    private async Task<IEnumerable<Domain.Entities.Location>> GetLocationsAsync(List<Identifier> locationIds)
    {
        var existingLocations = (await _locationRepository.GetByIdsAsync(locationIds)).ToList();
        
        if (existingLocations.Count < 1)
        {
            throw new InvalidOperationException(
                $"Zbyt malo");
        }
        
        var existingLocationIds = existingLocations.Select(location => location.Id);
        var missingLocationIds = locationIds.Except(existingLocationIds).ToList();

        if (missingLocationIds.Count > 0)
        {
            throw new InvalidOperationException(
                $"Nie znaleziono Location o ID: {string.Join(", ", missingLocationIds)}");
        }

        return existingLocations;
    }
    
    private async Task<IEnumerable<Domain.Entities.ExperienceLevel>> GetExperienceLevelsAsync(List<string> experienceLevelIds)
    {
        var existingExperienceLevels = (await _experienceLevelRepository.GetByIdsAsync(experienceLevelIds)).ToList();

        if (existingExperienceLevels.Count < 1)
        {
            throw new InvalidOperationException(
                $"Zbyt malo");
        }
        
        var existingExperienceLevelIds = existingExperienceLevels.Select(experienceLevel => experienceLevel.Id.ToString());
        var missingExperienceLevelIds = experienceLevelIds.Except(existingExperienceLevelIds).ToList();

        if (missingExperienceLevelIds.Count > 0)
        {
            throw new InvalidOperationException(
                $"Nie znaleziono missing ExperienceLevelIds o ID: {string.Join(", ", missingExperienceLevelIds)}");
        }

        return existingExperienceLevels;
    }
    
    private async Task<IEnumerable<Domain.Entities.Technology>> GetTechnologiesAsync(List<Identifier> technologyIds)
    {
        var existingTechnologies = (await _technologyRepository.GetByIdsAsync(technologyIds)).ToList();
        
        if (existingTechnologies.Count < 1)
        {
            throw new InvalidOperationException(
                $"Zbyt malo");
        }
        
        var existingTechnologyIds = existingTechnologies.Select(technology => technology.Id);
        var missingTechnologyIds = technologyIds.Except(existingTechnologyIds).ToList();

        if (missingTechnologyIds.Count > 0)
        {
            throw new InvalidOperationException(
                $"Nie znaleziono Technology o ID: {string.Join(", ", missingTechnologyIds)}");
        }

        return existingTechnologies;
    }
    
    private async Task<IEnumerable<Domain.Entities.EmploymentType>> GetEmploymentTypesAsync(List<string> employmentTypeIds)
    {
        var existingEmploymentTypes = (await _employmentTypeRepository.GetByIdsAsync(employmentTypeIds)).ToList();

        if (existingEmploymentTypes.Count < 1)
        {
            throw new InvalidOperationException(
                $"Zbyt malo");
        }
        
        var existingEmploymentTypeIds = existingEmploymentTypes.Select(employmentType => employmentType.Id.ToString());
        var missingEmploymentTypeIds = employmentTypeIds.Except(existingEmploymentTypeIds).ToList();

        if (missingEmploymentTypeIds.Count > 0)
        {
            throw new InvalidOperationException(
                $"Nie znaleziono missing EmploymentTypes o ID: {string.Join(", ", missingEmploymentTypeIds)}");
        }

        return existingEmploymentTypes;
    }

    private IEnumerable<Salary> GetSalaries(IEnumerable<Contract> contracts, Identifier offerId)
    {
        var salaries = new List<Salary>();
        foreach (var contract in contracts)
        {
            var salary = Salary.Create(
                Identifier.Create(),
                offerId,
                contract.EmploymentTypeId,
                contract.SalaryType,
                contract.SalaryMin,
                contract.SalaryMax,
                contract.SalaryFixed,
                contract.CurrencyCode,
                contract.BillingUnit
            );
            
            salaries.Add(salary);
        }
        return salaries;
    }
}