using Microsoft.EntityFrameworkCore;

namespace BGS.Infrastructure.Data;

internal static class DataBaseExtensionsConfig
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");
    }
}