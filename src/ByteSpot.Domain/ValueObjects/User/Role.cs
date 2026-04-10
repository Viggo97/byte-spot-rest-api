using System.Runtime.CompilerServices;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Exceptions.User;

namespace ByteSpot.Domain.ValueObjects.User;

public sealed record Role
{
    public static Role Admin() => new("Admin");
    public static Role Employer() => new("Recruiter");
    public static Role Candidate() => new("Candidate");
    public static IEnumerable<string> AvailableRoles { get; } = ["Admin", "Recruiter", "Candidate"];

    public string Value { get; }

    public Role(string value, [CallerArgumentExpression(nameof(value))] string? prop = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException(prop);
        }

        if (!AvailableRoles.Contains(value))
        {
            throw new InvalidRoleException(value, AvailableRoles);
        }

        Value = value;
    }
    
    public static implicit operator string(Role name) => name.Value;

    public static implicit operator Role(string name) => new(name);

    public override string ToString() => Value;
}