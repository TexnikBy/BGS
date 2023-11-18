using BGS.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BGS.Infrastructure.Data.EntityConfigurations;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Name)
            .IsUnique();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnType(PostgreSqlDataTypes.Citext);
    }
}