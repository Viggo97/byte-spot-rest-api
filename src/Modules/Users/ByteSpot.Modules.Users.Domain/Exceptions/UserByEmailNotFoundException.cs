using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class UserByEmailNotFoundException(string email) : ByteSpotException($"User with email: {email} was not found.")
{
    public string Email { get; } = email;
}