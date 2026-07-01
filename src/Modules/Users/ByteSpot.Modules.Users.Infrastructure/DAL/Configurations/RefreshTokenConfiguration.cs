using ByteSpot.Modules.Users.Domain.Entities;
using ByteSpot.Shared.Abstractions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteSpot.Modules.Users.Infrastructure.DAL.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder
            .Property(token => token.Token)
            .HasMaxLength(256);

        builder
            .HasIndex(token => token.Token)
            .IsUnique();

        builder
            .Property(token => token.Id)
            .HasConversion(id => id.Value, value => new Identifier(value));

        builder
            .Property(token => token.UserId)
            .HasConversion(id => id.Value, value => new Identifier(value));
    }
}