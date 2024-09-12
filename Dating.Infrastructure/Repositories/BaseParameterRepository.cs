using Dating.Domain.Models;
using Dating.Domain.Repositories;
using Dating.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Dating.Infrastructure.Repositories
{
    public abstract class BaseParameterRepository<T> : BaseRepository<T>, IParameterRepository<T> where T : BaseParameter
    {
        public BaseParameterRepository(DataBaseContext context, Func<DataBaseContext, DbSet<T>> getDbSet) : base(context, getDbSet) { }

        public async Task<T> Update(T entity)
        {
            var oldEntity = await GetById(entity.Id);

            oldEntity.Name = entity.Name;

            await context.SaveChangesAsync();
            return oldEntity;
        }
    }
}
