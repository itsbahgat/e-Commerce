using CloudinaryDotNet.Actions;

namespace E_Commerce.Interfaces
{
    public interface IPhotoService
    {
        Task <ImageUploadResult> UploadPhotoAsync(IFormFile file);
        Task <DeletionResult> DeletePhotoAsync(string publicId);
    }
}
