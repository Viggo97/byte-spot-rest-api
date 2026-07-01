using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class UserByIdNotFoundException(Guid id) : ByteSpotException($"User with id: {id} was not found.")
{
    public Guid Id { get; } = id;
}