using ByteSpot.Domain.Exceptions.Shared;

namespace ByteSpot.Domain.ValueObjects.Shared;

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

    public static Identifier Create() => Guid.NewGuid();

    public static implicit operator Guid(Identifier id)
        => id.Value;
    
    public static implicit operator Identifier(Guid value)
        => new(value);
}