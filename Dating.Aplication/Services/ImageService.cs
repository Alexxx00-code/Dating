using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
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
            var fileName = "Base" + DateTime.UtcNow.ToString() + Guid.NewGuid().ToString();
            await _imageRepository.SaveImageAsync(fileName, file);
            return fileName;
        }

        public async Task<Stream> GetImage(long id)
        {
            var imageUser = await _userImageRepository.GetById(id);
            if(imageUser.UserId != await _authService.GetUserId())
            {
                throw new NoAccessException();
            }


            return await _imageRepository.GetImageAsync(imageUser.Path);
        }


        public async Task<ImageModel> UploadImageForUserAsync(Stream file)
        {
            var fileName = DateTime.UtcNow.ToString() + Guid.NewGuid().ToString();

            await _imageRepository.SaveImageAsync(fileName, file);
            var userId = await _authService.GetUserId();

            var imageModel = ImageModel.ToModel(await _userImageRepository.Create(new UserImage { Path = fileName, UserId = userId }));

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
