using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public sealed class InvalidEmailException(string email, int minLength, int maxLength)
    : ByteSpotException(
        $"Email {email} contains {email.Length} characters, but should be between {minLength} and {maxLength}.")
{
    public string Email { get; } = email;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}