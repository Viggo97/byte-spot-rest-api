using ByteSpot.Shared.Abstractions.Queries;

namespace ByteSpot.Modules.Users.Application.Queries;

public sealed record GetEmailAvailabilityQuery(string Email) : IQuery<bool>;