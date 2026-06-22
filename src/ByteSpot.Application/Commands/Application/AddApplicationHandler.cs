using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Repositories;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Commands.Application;

public sealed class AddApplicationHandler : ICommandHandler<AddApplicationCommand>
{
    private readonly IApplicationRepository _applicationRepository;

    public AddApplicationHandler(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public async Task HandleAsync(AddApplicationCommand command)
    {
        var applicationId = Identifier.Create();
        var offerId = Identifier.Create(command.OfferId);
        var resumeId = Identifier.Create();
        var candidateFirstName = new FirstName(command.CandidateFirstName);
        var candidateLastName = new LastName(command.CandidateLastName);
        var candidateEmail = new Email(command.CandidateEmail);
        
        var application = Domain.Entities.Application.Create(applicationId, candidateFirstName, candidateLastName, candidateEmail, offerId, resumeId);
        
        await _applicationRepository.AddAsync(application);
        
        //TODO Handle resume saving
    }
}