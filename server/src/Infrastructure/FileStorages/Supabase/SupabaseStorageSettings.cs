namespace BGS.Infrastructure.FileStorages.Supabase;

public record SupabaseStorageSettings
{
    public string Url { get; init; }

    public string ApiKey { get; init; }

    public string BucketId { get; init; }

    public string JwtSecret { get; init; }
}