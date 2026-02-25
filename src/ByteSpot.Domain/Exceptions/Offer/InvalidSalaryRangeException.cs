namespace ByteSpot.Domain.Exceptions.Offer;

public sealed class InvalidSalaryRangeException(int salaryMin, int salaryMax)
    : CustomException($"Minimum salary [{salaryMin}] cannot be greater than maximum salary [{salaryMax}].")
{
    public int SalaryMin { get; } = salaryMin;
    public int SalaryMax { get;  } = salaryMax;
}