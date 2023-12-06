namespace BGS.SharedKernel.FileStorages;

public record FileModel(string Name, Func<Stream> OpenReadStream);