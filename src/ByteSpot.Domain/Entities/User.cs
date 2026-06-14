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
    public RefreshToken? RefreshToken { get; set; }

    private User(Identifier id, Email email, Password password, Role role, FirstName firstName, LastName lastName,
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

    public static User Create(Identifier id, Email email, Password password, Role role, FirstName firstName,
        LastName lastName, DateTimeOffset createdAt)
        => new(id, email, password, role, firstName, lastName, createdAt);

    public void ChangeFirstName(string firstName)
    {
        FirstName = new FirstName(firstName);
    }
    
    public void ChangeLastName(string lastName)
    {
        LastName = new LastName(lastName);
    }
}