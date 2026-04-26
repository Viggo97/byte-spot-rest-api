namespace ByteSpot.Application.Abstractions;

public interface IClock
{
    DateTimeOffset Now();
}