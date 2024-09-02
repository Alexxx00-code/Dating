using Dating.Domain.Models;

namespace Dating.Domain.Repositories
{
    public interface IParameterRepository<T> where T : BaseParameter
    {
        IQueryable<T> GetAll();
        Task<T> GetById(long id);
        Task<T> Create (T entity);
        Task<T> Update (T entity);
        Task<T> DeleteById (long id);
    }
}
