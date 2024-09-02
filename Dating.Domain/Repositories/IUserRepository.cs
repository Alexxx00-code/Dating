using Dating.Domain.Models;

namespace Dating.Domain.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> GetById(long id);
        Task<User> Create(User entity);
        Task<User> Update(User entity);
        Task<User> DeleteById(long id);
    }
}
