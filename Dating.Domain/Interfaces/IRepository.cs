using Dating.Domain.Models;

namespace Dating.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        Task<T> GetById(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> DeleteById(long id);
    }
}
