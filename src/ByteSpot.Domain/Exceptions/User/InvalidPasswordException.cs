namespace ByteSpot.Domain.Exceptions.User;

public sealed class InvalidPasswordException(string password, int minLength, int maxLength) 
    : CustomException($"Password contains {password.Length} characters, but should be between {minLength} and {maxLength}.")
{
    public string Password { get; } = password;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}