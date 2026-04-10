namespace ByteSpot.Domain.Exceptions.User;

public sealed class InvalidEmailException(string email, int minLength, int maxLength)
    : CustomException(
        $"Email {email} contains {email.Length} characters, but should be between {minLength} and {maxLength}.")
{
    public string Email { get; } = email;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}