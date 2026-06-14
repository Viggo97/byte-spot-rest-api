namespace ByteSpot.Domain.Exceptions.User;

public class UserByEmailNotFoundException(string email) : CustomException($"User with email: {email} was not found.")
{
    public string Email { get; } = email;
}