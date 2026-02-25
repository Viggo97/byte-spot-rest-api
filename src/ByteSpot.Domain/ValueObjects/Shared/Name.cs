using ByteSpot.Domain.Exceptions.Shared;

namespace ByteSpot.Domain.ValueObjects.Shared;

public sealed record Name
{
    public string Value { get; }
    
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException();
        }
        
        var trimmedValue = value.Trim();
        
        const int minLength = 2;
        const int maxLength = 128;
        if (value.Length is > maxLength or < minLength)
        {
            throw new StringLengthOutOfRangeException(value, minLength, maxLength);
        }

        Value = trimmedValue;
    }
    
    public static implicit operator string(Name name) => name.Value;

    public static implicit operator Name(string name) => new(name);

    public override string ToString() => Value;
}