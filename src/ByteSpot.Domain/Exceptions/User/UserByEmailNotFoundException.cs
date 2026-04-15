namespace ByteSpot.Domain.Exceptions.User;

public class UserByIdNotFoundException(string id) : CustomException($"User with id: {id} was not found.")
{
    public string Id { get; } = id;
}