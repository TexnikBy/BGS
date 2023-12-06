using System.IO;
using System.Threading.Tasks;
using BGS.SharedKernel.FileStorages;

namespace BGS.Infrastructure.FileStorages.System;

internal class SystemFileStorage(SystemStorageSettings settings) : IFileStorage
{
    public async Task<string> Upload(FileModel model)
    {
        var fileReference = Path.Combine(settings.RootPath, model.Name);
        await using var readStream = model.OpenReadStream();
        await using var fileStream = File.Create(fileReference);
        readStream.Seek(0, SeekOrigin.Begin);
        await readStream.CopyToAsync(fileStream);

        return fileReference;
    }
}