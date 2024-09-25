using Dating.Domain.Interfaces;

namespace Dating.Infrastructure.Repositories
{
    public class FileImageRepository : IImageRepository
    {
        private readonly string _uploadsFolder;

        public FileImageRepository(string uploadsFolder)
        {
            _uploadsFolder = uploadsFolder;
        }

        public async Task SaveImageAsync(string fileName, Stream imageData)
        {
            var filePath = Path.Combine(_uploadsFolder, fileName);
            var fileStream = File.Open(filePath, FileMode.CreateNew);
            await imageData.CopyToAsync(fileStream);
        }

        public async Task DeleteImageAsync(string fileName)
        {
            var filePath = Path.Combine(_uploadsFolder, fileName);
            File.Delete(filePath);
        }

        public async Task<Stream> GetImageAsync(string fileName)
        {
            var filePath = Path.Combine(_uploadsFolder, fileName);
            return File.OpenRead(filePath);
        }
    }
}
