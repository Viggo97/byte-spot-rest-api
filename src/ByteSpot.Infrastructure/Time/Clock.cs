using ByteSpot.Application.Abstractions;

namespace ByteSpot.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTimeOffset Now() => DateTimeOffset.UtcNow;
}