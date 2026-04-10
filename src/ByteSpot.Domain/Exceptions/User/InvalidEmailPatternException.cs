namespace ByteSpot.Domain.Exceptions.User;

public sealed class InvalidEmailPatternException(string email) : CustomException($"Email: {email} is invalid.")
{
    public string Email { get; } = email;
}