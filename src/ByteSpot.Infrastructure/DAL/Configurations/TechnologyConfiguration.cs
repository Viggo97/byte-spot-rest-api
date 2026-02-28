using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.Technology;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        builder
            .Property(technology => technology.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));

        builder
            .Property(technology => technology.Name)
            .HasMaxLength(128)
            .HasConversion(name => name.Value, value => new Name(value));

        builder
            .Property(technology => technology.IconCode)
            .HasConversion(iconCode => iconCode.Value, value => new IconCode(value));
    }
}