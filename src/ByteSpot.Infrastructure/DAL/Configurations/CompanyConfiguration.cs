using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder
            .Property(company => company.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));

        builder
            .Property(company => company.Name)
            .HasMaxLength(128)
            .HasConversion(name => name.Value, value => new Name(value));
    }
}