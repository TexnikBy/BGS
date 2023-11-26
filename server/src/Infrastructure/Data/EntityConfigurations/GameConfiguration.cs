using BGS.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BGS.Infrastructure.Data.EntityConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);

        builder.HasIndex(g => g.Name)
            .IsUnique();

        builder.Property(g => g.Name)
            .HasMaxLength(DataSchemaConstants.GameNameColumnLength)
            .IsRequired()
            .HasColumnType(PostgreSqlDataTypes.Citext);
    }
}