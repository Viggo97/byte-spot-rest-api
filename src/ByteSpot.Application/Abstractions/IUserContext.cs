using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Application.Abstractions;

public interface IUserContext
{
    string? Id { get; }
    string? Email { get; }
    Role? Role { get; }
}