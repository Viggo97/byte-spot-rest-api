using System.Xml.Linq;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Exceptions.Technology;

namespace ByteSpot.Domain.ValueObjects.Technology;

public sealed record IconCode
{
    public string Value { get; }

    public IconCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException();
        }

        var trimmedValue = value.Trim();

        const int minLength = 8;
        const int maxLength = 512_000;
        if (trimmedValue.Length is > maxLength or < minLength)
        {
            throw new StringLengthOutOfRangeException(trimmedValue, minLength, maxLength);
        }

        var containsSvgTags = trimmedValue.StartsWith("<svg") && trimmedValue.EndsWith("</svg>");
        if (!containsSvgTags)
        {
            throw new InvalidSvgTagException();
        }


        try
        {
            XDocument.Parse(trimmedValue);
        }
        catch
        {
            throw new InvalidSvgStructureException();
        }
        
        // Security validation should be implemented here.
        
        Value = trimmedValue;
    }
    
    public static implicit operator string(IconCode name) => name.Value;

    public static implicit operator IconCode(string name) => new(name);

    public override string ToString() => Value;
}