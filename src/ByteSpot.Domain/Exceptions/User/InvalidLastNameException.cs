namespace ByteSpot.Domain.Exceptions.User;

public sealed class InvalidLastNameException(string lastName, int minLength, int maxLength)
    : CustomException(
        $"Last name: {lastName} contains {lastName.Length} characters, but should be between {minLength} and {maxLength}.")
{
    public string Last { get; } = lastName;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}