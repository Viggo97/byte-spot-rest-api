using ByteSpot.Domain.Entities;
using ByteSpot.Domain.ValueObjects.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Infrastructure.DAL.Configurations;

internal sealed class WorkModeConfiguration : IEntityTypeConfiguration<WorkMode>
{
    public void Configure(EntityTypeBuilder<WorkMode> builder)
    {
        builder
            .Property(workMode => workMode.Name)
            .HasMaxLength(128)
            .HasConversion(name => name.Value, value => new Name(value));
    }
}