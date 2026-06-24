namespace ByteSpot.Bootstrapper.Files;

public sealed record AddApplicationDocument(
    string OfferId,
    string CandidateFirstName,
    string CandidateLastName,
    string CandidateEmail,
    IFormFile Resume
);