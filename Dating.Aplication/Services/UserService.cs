using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
using Dating.Aplication.Utilities;
using Dating.Domain.Interfaces;
using Dating.Domain.Models;

namespace Dating.Aplication.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IEnvParameters _envParameters;
        private readonly ICityApi _cityApi;

        public UserService(IRepository<User> userRepository, IEnvParameters envParameters, ICityApi citiApi, IRepository<City> cityRepository)
        {
            _userRepository = userRepository;
            _cityRepository = cityRepository;
            _envParameters = envParameters;
            _cityApi = citiApi;
        }

        public async Task<UserModel> Create(CreateUserModel newUser)
        {
            var userOld = _userRepository.GetAll().Where(i => i.TelegramId == _envParameters.TelegramId).FirstOrDefault();

            if(userOld != null)
            {
                throw new Exception();
            }

            var cityName = await _cityApi.GetCityName(newUser.Latitude, newUser.Longitude);

            var city = _cityRepository.GetAll().Where(i => i.Name == cityName).FirstOrDefault();

            if (city == null)
            {
                city = await _cityRepository.Create(new City { Name = cityName });
            }

            User user = new User {
                Firstname = newUser.Firstname,
                TelegramId = _envParameters.TelegramId,
                Birthdate = newUser.Birthdate,
                GenderId = newUser.GenderId,
                SexOrientationId = newUser.SexOrientationId,
                Latitude = newUser.Latitude,
                Longitude = newUser.Longitude,
                CityId = city.Id,
                BaseImageName = newUser.BaseImagePath,
            };
            var userRes = await _userRepository.Create(user);
            return _userRepository.GetAll().Where(i => i.Id == userRes.Id).ToModel().First();
        }

        public async Task<UserModel> GetUser()
        {
            var user = _userRepository.GetAll().Where(i => i.TelegramId == _envParameters.TelegramId).ToModel().FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User is not registered");
            }

            return user;
        }
    }
}
