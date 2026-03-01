using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

internal sealed class ExperienceLevelConfiguration : IEntityTypeConfiguration<ExperienceLevel>
{
    public void Configure(EntityTypeBuilder<ExperienceLevel> builder)
    {
        builder
            .Property(experienceLevel => experienceLevel.Name)
            .HasMaxLength(128)
            .HasConversion(name => name.Value, value => new Name(value));
    }
}