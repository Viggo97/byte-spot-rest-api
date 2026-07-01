namespace ByteSpot.Shared.Abstractions.Exceptions.Common;

public class InvalidIdentifierException(object id) : ByteSpotException($"Cannot set: {id} as identifier.")
{
    public object Id { get; } = id;
}