using System.Runtime.CompilerServices;
using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Shared.Abstractions.Exceptions.Common;

namespace ByteSpot.Modules.Users.Domain.ValueObjects;

public sealed record Role
{
    public static Role Admin() => new("Admin");
    public static Role Employer() => new("Employer");
    public static Role Recruiter() => new("Recruiter");
    public static Role Candidate() => new("Candidate");
    public static IEnumerable<string> AvailableRoles { get; } = ["Admin", "Employer", "Recruiter", "Candidate"];

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