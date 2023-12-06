using System;
using BGS.Infrastructure.FileStorages.Supabase;
using BGS.Infrastructure.FileStorages.System;
using BGS.SharedKernel.FileStorages;
using Microsoft.Extensions.Options;

namespace BGS.Infrastructure.FileStorages;

internal class FileStorageFactory(
        Lazy<IOptions<FileStorageSettings>> fileStorageOptions,
        Lazy<IOptions<SystemStorageSettings>> systemStorageOptions,
        Lazy<IOptions<SupabaseStorageSettings>> supabaseStorageOptions)
    : IFileStorageFactory
{
    public IFileStorage Create() => Create(fileStorageOptions.Value.Value.StorageType);
    
    private IFileStorage Create(FileStorageType type) => type switch
    {
        FileStorageType.System => new SystemFileStorage(systemStorageOptions.Value.Value),
        FileStorageType.Supabase => new SupabaseStorage(supabaseStorageOptions.Value.Value),
        _ => throw new InvalidOperationException($"No storage implementation was found for file type '{type}'."),
    };
}