using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class EmailAlreadyInUseException(string email) : ByteSpotException($"Email {email} is already in use.")
{
    public string Email { get; } = email;
}