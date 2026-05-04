namespace ByteSpot.Domain.Exceptions.Offer;

public sealed class OfferNotFoundException(Guid id) : CustomException($"Offer with id: {id} was not found.")
{
    public Guid Id { get; } = id;
}