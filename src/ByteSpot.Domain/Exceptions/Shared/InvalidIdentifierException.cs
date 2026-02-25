namespace ByteSpot.Domain.Exceptions.Shared;

public class InvalidIdentifierException(object id) : CustomException($"Cannot set: {id} as identifier.")
{
    public object Id { get; } = id;
}