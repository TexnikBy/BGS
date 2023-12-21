namespace BGS.Infrastructure.FileStorages;

public record FileStorageSettings
{
    public FileStorageType StorageType { get; init; }
}