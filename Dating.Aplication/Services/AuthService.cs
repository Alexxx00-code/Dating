using Dating.Aplication.Interfaces;
using Dating.Domain.Interfaces;
using Dating.Domain.Models;

namespace Dating.Aplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IEnvParameters _envParameters;

        public AuthService(IRepository<User> userRepository, IEnvParameters envParameters)
        {
            _userRepository = userRepository;
            _envParameters = envParameters;
        }

        public async Task<long> GetUserId()
        {
            var userIds = _userRepository.GetAll().Where(i => i.TelegramId == _envParameters.TelegramId).Select(i => i.Id).ToArray();

            if (userIds.Length != 1)
            {
                throw new Exception();
            }
            else
            {
                return userIds[0];
            }
        }
    }
}
