namespace Dating.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task SaveImageAsync(string fileName, Stream imageData);

        Task DeleteImageAsync(string fileName);

        Task<Stream> GetImageAsync(string fileName);
    }
}
