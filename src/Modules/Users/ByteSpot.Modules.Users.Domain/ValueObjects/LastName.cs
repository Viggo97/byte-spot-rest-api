using System.Runtime.CompilerServices;
using ByteSpot.Modules.Users.Domain.Exceptions;
using ByteSpot.Shared.Abstractions.Exceptions.Common;

namespace ByteSpot.Modules.Users.Domain.ValueObjects;

public sealed record LastName
{
    public string Value { get; }
        
    public LastName(string value, [CallerArgumentExpression(nameof(value))] string? prop = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException(prop);
        }
        
        var trimmedValue = value.Trim();

        const int minLength = 3;
        const int maxLength = 64;
        if (trimmedValue.Length is > maxLength or < minLength)
        {
            throw new InvalidLastNameException(trimmedValue, minLength, maxLength);
        }
            
        Value = value;
    }

    public static implicit operator string(LastName name) => name.Value;

    public static implicit operator LastName(string name) => new(name);

    public override string ToString() => Value;
}