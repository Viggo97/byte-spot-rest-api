using System.Runtime.CompilerServices;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Exceptions.User;

namespace ByteSpot.Domain.ValueObjects.User;

public sealed record Password
{
    public string Value { get; }
        
    public Password(string value, [CallerArgumentExpression(nameof(value))] string? prop = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException(prop);
        }
        
        var trimmedValue = value.Trim();

        const int minLength = 8;
        const int maxLength = 100;
        if (trimmedValue.Length is > maxLength or < minLength)
        {
            throw new InvalidPasswordException(trimmedValue, minLength, maxLength);
        }
            
        Value = value;
    }

    public static implicit operator string(Password name) => name.Value;

    public static implicit operator Password(string name) => new(name);

    public override string ToString() => Value;
}