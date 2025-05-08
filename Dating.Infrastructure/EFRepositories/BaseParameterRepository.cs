using Dating.Domain.Models;
using Dating.Domain.Interfaces;
using Dating.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Dating.Infrastructure.EFRepositories
{
    public abstract class BaseParameterRepository<T> : BaseRepository<T>, IRepository<T> where T : BaseParameter
    {
        public BaseParameterRepository(DataBaseContext context, Func<DataBaseContext, DbSet<T>> getDbSet) : base(context, getDbSet) { }

        public virtual async Task<bool> Update(T entity)
        {
            var oldEntity = await GetById(entity.Id);

            oldEntity.Name = entity.Name;

            return await context.SaveChangesAsync() > 0;
        }
    }
}
