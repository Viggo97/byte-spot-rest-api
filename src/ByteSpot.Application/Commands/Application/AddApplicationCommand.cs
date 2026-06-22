using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Application;

public sealed record AddApplicationCommand(
    string OfferId,
    string CandidateFirstName,
    string CandidateLastName,
    string CandidateEmail,
    Stream Resume
) : ICommand;