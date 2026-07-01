using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public sealed class InvalidLastNameException(string lastName, int minLength, int maxLength)
    : ByteSpotException(
        $"Last name: {lastName} contains {lastName.Length} characters, but should be between {minLength} and {maxLength}.")
{
    public string Last { get; } = lastName;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}