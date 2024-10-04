using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
using Dating.Aplication.Utilities;
using Dating.Domain.Exceptions;
using Dating.Domain.Interfaces;
using Dating.Domain.Models;
using System.IO;

namespace Dating.Aplication.Services
{
    public class ImageService : IImageService
    {
        private readonly IRepository<UserImage> _userImageRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IAuthService _authService;

        public ImageService(IImageRepository imageRepository, IRepository<UserImage> repository, IAuthService authService)
        {
            _imageRepository = imageRepository;
            _userImageRepository = repository;
            _authService = authService;
        }

        public async Task<string> UploadImageAsync(Stream file)
        {
            var fileName = "Base" + DateTime.UtcNow.ToString("d_M_yyyy_HH_mm_ss") + Guid.NewGuid().ToString();
            await _imageRepository.SaveImageAsync(fileName, file);
            return fileName;
        }

        public async Task<byte[]> GetImage(long id)
        {
            var imageUser = await _userImageRepository.GetById(id);
            return await _imageRepository.GetImageAsync(imageUser.Path);
        }


        public async Task<ImageModel> UploadImageForUserAsync(Stream file)
        {
            var fileName = DateTime.UtcNow.ToString("d_M_yyyy_HH_mm_ss") + Guid.NewGuid().ToString();

            await _imageRepository.SaveImageAsync(fileName, file);
            var userId = await _authService.GetUserId();

            var imageModel = (await _userImageRepository.Create(new UserImage { Path = fileName, UserId = userId })).ToModel();

            return imageModel;
        }

        public async Task DeleteImage(long id)
        {
            var imageUser = await _userImageRepository.GetById(id);

            var userId = await _authService.GetUserId();
            if (imageUser.UserId != userId)
            {
                throw new NoAccessException();
            }

            await _userImageRepository.DeleteById(id);
            await _imageRepository.DeleteImageAsync(imageUser.Path);
        }
    }
}
