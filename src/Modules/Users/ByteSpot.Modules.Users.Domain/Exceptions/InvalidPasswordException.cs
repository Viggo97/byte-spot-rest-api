using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public sealed class InvalidPasswordException(string password, int minLength, int maxLength) 
    : ByteSpotException($"Password contains {password.Length} characters, but should be between {minLength} and {maxLength}.")
{
    public string Password { get; } = password;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}