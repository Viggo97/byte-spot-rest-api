using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Domain.Entities;

public class Application
{
    public Identifier Id { get; private set; }
    public FirstName CandidateFirstName { get; private set; }
    public LastName CandidateLastName { get; private set; }
    public Email CandidateEmail { get; private set; }
    public Identifier OfferId { get; private set; }
    public Identifier ResumeId { get; private set; }

    public Application(Identifier id, FirstName candidateFirstName, LastName candidateLastName,
        Email candidateEmail, Identifier offerId, Identifier resumeId)
    {
        Id = id;
        CandidateFirstName = candidateFirstName;
        CandidateLastName = candidateLastName;
        CandidateEmail = candidateEmail;
        OfferId = offerId;
        ResumeId = resumeId;
    }

    public static Application Create(Identifier id, FirstName candidateFirstName, LastName candidateLastName,
        Email candidateEmail, Identifier offerId, Identifier resumeId)
        => new (id, candidateFirstName, candidateLastName, candidateEmail, offerId, resumeId);
}