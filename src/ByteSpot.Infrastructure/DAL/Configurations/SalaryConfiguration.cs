using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

public class SalaryConfiguration :  IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        builder
            .Property(salary => salary.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));
        
        builder
            .Property(salary => salary.OfferId)
            .HasConversion(id => id.Value, value => new Identifier(value));

        builder
            .Property(salary => salary.Currency)
            .HasMaxLength(3)
            .HasConversion(currency => currency.Code, code => new Currency(code));
    }
}