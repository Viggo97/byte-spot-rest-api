using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Queries.User;

public sealed record GetEmailAvailabilityQuery(string Email) : IQuery<bool>;