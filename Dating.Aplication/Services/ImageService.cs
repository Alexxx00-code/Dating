using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
using Dating.Aplication.Utilities;
using Dating.Domain.Exceptions;
using Dating.Domain.Interfaces;
using Dating.Domain.Models;
using Dating.FaceRecognition;

namespace Dating.Aplication.Services
{
    public class ImageService : IImageService
    {
        private readonly IRepository<UserImage> _userImageRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IAuthService _authService;
        private readonly FaceCompare faceCompare;

        public ImageService(IImageRepository imageRepository, IRepository<UserImage> userImageRepository, IRepository<User> userRepository, IAuthService authService, FaceCompare faceCompare)
        {
            _imageRepository = imageRepository;
            _userImageRepository = userImageRepository;
            _userRepository = userRepository;
            _authService = authService;
            this.faceCompare = faceCompare;
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

        public async Task<ImageModel[]> UploadImagesForUserAsync(List<Stream> files)
        {
            var userId = await _authService.GetUserId();
            var userImageVerCount = _userImageRepository.GetAll().Count(i => i.UserId == userId && i.FaceVerification);
            var user = await _userRepository.GetById(userId);
            var baseImage = await _imageRepository.GetImageAsync(user.BaseImageName);
            var baseImageStream = new MemoryStream(baseImage);

            var newUserImageVerList = files.Select(i => faceCompare.FaceCheckMatch(baseImageStream, i)).ToList();

            if (newUserImageVerList.Count(i => i) + userImageVerCount < 4)
            {
                throw new ValidateException("There are not enough face images");
            }
            if (files.Count + _userImageRepository.GetAll().Count(i => i.UserId == userId) > 10)
            {
                throw new ValidateException("Lots of images");
            }

            List<ImageModel> imageModels = new List<ImageModel>(files.Count);
            try
            {
                var verificationEnum = newUserImageVerList.GetEnumerator();
                foreach (var image in files)
                {
                    var fileName = await UploadImageForUserAsync(image);
                    verificationEnum.MoveNext();
                    var imageModel = (await _userImageRepository.Create(new UserImage { Path = fileName, UserId = userId, FaceVerification = verificationEnum.Current })).ToModel();
                    imageModels.Add(imageModel);
                }
            }
            catch
            {
                foreach(var imageModel in imageModels)
                {
                    await DeleteImage(imageModel.Id);
                }
                throw;
            }

            return imageModels.ToArray();
        }

        public async Task<string> UploadImageForUserAsync(Stream file)
        {
            var fileName = DateTime.UtcNow.ToString("d_M_yyyy_HH_mm_ss") + Guid.NewGuid().ToString();

            await _imageRepository.SaveImageAsync(fileName, file);

            return fileName;
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
