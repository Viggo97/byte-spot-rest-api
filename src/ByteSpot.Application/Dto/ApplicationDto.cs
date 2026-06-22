namespace ByteSpot.Application.Dto;

public sealed record ApplicationDto(
    string Id,
    string CandidateFirstName,
    string CandidateLastName,
    string CandidateEmail
);