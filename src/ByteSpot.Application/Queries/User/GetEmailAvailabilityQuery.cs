using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Queries.User;

public sealed record GetEmailAvailabilityQuery(Email Email) : IQuery<bool>;