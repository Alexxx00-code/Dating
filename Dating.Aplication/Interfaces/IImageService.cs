using Dating.Aplication.Models;

namespace Dating.Aplication.Interfaces
{
    public interface IImageService
    {
        Task<Stream> GetImage(long id);

        Task<string> UploadImageAsync(Stream file);

        Task<ImageModel> UploadImageForUserAsync(Stream file);

        Task DeleteImage(long id);
    }
}
