using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.User;

namespace ByteSpot.Domain.Entities;

public class User
{
    public Identifier Id { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Role Role { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public User(Identifier id, Email email, Password password, Role role, FirstName firstName, LastName lastName,
        DateTimeOffset createdAt)
    {
        Id = id;
        Email = email;
        Password = password;
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = createdAt;
    }
}