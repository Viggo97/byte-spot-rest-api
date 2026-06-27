using ByteSpot.Shared.Abstractions.Exceptions.Common;

namespace ByteSpot.Shared.Abstractions.ValueObjects;

public sealed record Identifier
{
    public Guid Value { get; }

    public Identifier(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidIdentifierException(value);
        }

        Value = value;
    }

    public Identifier(string value)
    {
        if (value == string.Empty)
        {
            throw new  InvalidIdentifierException(value);
        }
        
        Value = Guid.Parse(value);
    }

    public static Identifier Create() => new(Guid.NewGuid());
    public static Identifier Create(Guid id) => new(id);
    public static Identifier Create(string id) => new(id);

    public static implicit operator Guid(Identifier id)
        => id.Value;
    
    public static implicit operator Identifier(Guid value)
        => new(value);
}