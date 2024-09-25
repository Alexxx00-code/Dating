using Dating.Domain.Exceptions;
using Dating.Domain.Models;
using Dating.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Dating.Infrastructure.EFRepositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly DataBaseContext context;

        protected readonly Func<DataBaseContext, DbSet<T>> getDbSet;

        public BaseRepository(DataBaseContext context, Func<DataBaseContext, DbSet<T>> getDbSet)
        {
            this.context = context;
            this.getDbSet = getDbSet;
        }

        public virtual IQueryable<T> GetAll()
        {
            return getDbSet(context).AsNoTracking();
        }

        public virtual async Task<T> GetById(long id)
        {
            T? item = await getDbSet(context).FirstOrDefaultAsync(i => i.Id == id);
            return item is null ? throw new NotExistException(typeof(T), id) : item;
        }

        public virtual async Task<T> Create(T entity)
        {
            var newEntity = context.Add(entity);
            await context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public virtual async Task<T> DeleteById(long id)
        {
            var item = await GetById(id);

            getDbSet(context).Remove(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
