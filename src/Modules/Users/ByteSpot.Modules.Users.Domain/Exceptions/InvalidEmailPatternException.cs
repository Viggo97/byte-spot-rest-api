using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public sealed class InvalidEmailPatternException(string email) : ByteSpotException($"Email: {email} is invalid.")
{
    public string Email { get; } = email;
}