using BGS.SharedKernel.FileStorages;

namespace BGS.Api.Extensions;

internal static class FormFileExtensions
{
    public static FileModel ToFileModel(this IFormFile formFile)
    {
        return formFile is null ? null : new FileModel(formFile.FileName, formFile.OpenReadStream);
    }
}