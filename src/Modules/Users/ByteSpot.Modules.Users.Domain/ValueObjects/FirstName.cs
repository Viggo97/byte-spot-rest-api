using System.Runtime.CompilerServices;
using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Shared.Abstractions.Exceptions.Common;

namespace ByteSpot.Modules.Users.Domain.ValueObjects;

public sealed record FirstName
{
    public string Value { get; }
        
    public FirstName(string value, [CallerArgumentExpression(nameof(value))] string? prop = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException(prop);
        }
        
        var trimmedValue = value.Trim();

        const int minLength = 2;
        const int maxLength = 32;
        if (trimmedValue.Length is > maxLength or < minLength)
        {
            throw new InvalidFirstNameException(trimmedValue, minLength, maxLength);
        }
            
        Value = value;
    }

    public static implicit operator string(FirstName name) => name.Value;

    public static implicit operator FirstName(string name) => new(name);

    public override string ToString() => Value;
}