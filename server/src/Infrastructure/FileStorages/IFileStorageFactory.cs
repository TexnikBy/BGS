using BGS.SharedKernel.FileStorages;

namespace BGS.Infrastructure.FileStorages;

public interface IFileStorageFactory
{
    IFileStorage Create();
}