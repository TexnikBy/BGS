namespace BGS.SharedKernel.FileStorages;

public interface IFileStorage
{
    Task<string> Upload(FileModel model);
}