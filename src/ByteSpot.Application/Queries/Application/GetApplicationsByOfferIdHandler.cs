using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Application;

public class GetApplicationsByOfferIdHandler : IQueryHandler<GetApplicationsByOfferIdQuery, IEnumerable<ApplicationDto>>
{
    private readonly IApplicationRepository _applicationRepository;

    public GetApplicationsByOfferIdHandler(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public async Task<IEnumerable<ApplicationDto>> HandleAsync(GetApplicationsByOfferIdQuery query)
    {
        var applications = await _applicationRepository.GetAllAsync();
        return applications.Select(application => new ApplicationDto(
            application.Id.Value.ToString(), 
            application.CandidateFirstName, 
            application.CandidateLastName, 
            application.CandidateEmail
            )
        ) ;
    }
}