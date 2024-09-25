using Dating.Aplication.Models;

namespace Dating.Aplication.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Create(CreateUserModel userModel);
        Task<UserModel> GetUser();
    }
}
