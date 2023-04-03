using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using E_Commerce.Interfaces;
using Microsoft.Extensions.Options;

namespace E_Commerce.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService() {

            _cloudinary = new Cloudinary(new Account("ducv5uad3", "511721446839581", "7YEzhl_caVKlD2H-1ws2O4d2M-c"));
 
            }

        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile file)
        {
            if (file is null) throw new ArgumentNullException(nameof(file));

            if (file.Length == 0)
                throw new ArgumentException("The file is empty.", nameof(file));

            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult;
        }


        public Task<DeletionResult> DeletePhotoAsync(string publicId)
        {

            //@TODO
            throw new NotImplementedException();
        }
    }
}
