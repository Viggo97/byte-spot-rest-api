namespace ByteSpot.Domain.Exceptions.User;

public class UserByIdNotFoundException(Guid id) : CustomException($"User with id: {id} was not found.")
{
    public Guid Id { get; } = id;
}