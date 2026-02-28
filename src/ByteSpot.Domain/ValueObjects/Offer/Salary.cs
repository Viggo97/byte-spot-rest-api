using ByteSpot.Domain.Exceptions.Offer;

namespace ByteSpot.Domain.ValueObjects.Offer;

public sealed record Salary
{
    public int? Min { get; }
    public int? Max { get; }
    public int? Fixed { get; }
    
    private Salary() {}

    public Salary(int value)
    {
        Fixed = value;
    }
    
    public Salary(int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            throw new InvalidSalaryRangeException(minValue, maxValue);
        }
            
        Min = minValue;
        Max = maxValue;
    }

    public override string ToString() => Fixed is not null 
        ? Fixed.Value.ToString() 
        : $"{Min} - {Max}";
}