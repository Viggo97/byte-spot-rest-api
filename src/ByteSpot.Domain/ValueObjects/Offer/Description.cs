using ByteSpot.Domain.Exceptions.Shared;

namespace ByteSpot.Domain.ValueObjects.Offer;

public sealed record Description
{
    public string Value { get; }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException();
        }
        
        const int minLength = 32;
        const int maxLength = 1200;
        if (value.Length is > maxLength or < minLength)
        {
            throw new StringLengthOutOfRangeException(value, minLength, maxLength);
        }
            
        Value = value;
    }
    
    public static implicit operator string(Description description) => description.Value;
    
    public static implicit operator Description(string description) => new (description);
    
    public override string ToString() => Value;
}