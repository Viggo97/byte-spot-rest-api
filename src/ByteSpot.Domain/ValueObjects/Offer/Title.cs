using ByteSpot.Domain.Exceptions.Offer;
using ByteSpot.Domain.Exceptions.Shared;

namespace ByteSpot.Domain.ValueObjects.Offer;

public sealed record Title
{
    public string Value { get; }
    
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException();
        }
        
        const int minLength = 12;
        const int maxLength = 80;
        if (value.Length is > maxLength or < minLength)
        {
            throw new StringLengthOutOfRangeException(value, minLength, maxLength);
        }
            
        Value = value;
    }
    
    public static implicit operator string(Title title) => title.Value;
    
    public static implicit operator Title(string title) => new (title);
    
    public override string ToString() => Value;
}
