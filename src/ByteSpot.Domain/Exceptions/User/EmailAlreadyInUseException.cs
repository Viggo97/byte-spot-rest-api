namespace ByteSpot.Domain.Exceptions.User;

public class EmailAlreadyInUseException(string email) : CustomException($"Email {email} is already in use.")
{
    public string Email { get; } = email;
}