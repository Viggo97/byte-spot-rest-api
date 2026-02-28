using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

internal sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .Property(location => location.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));

        builder
            .Property(location => location.Name)
            .HasMaxLength(128)
            .HasConversion(name => name.Value, value => new Name(value));
    }
}