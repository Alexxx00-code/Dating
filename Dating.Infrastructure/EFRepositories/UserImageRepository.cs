using Dating.Domain.Interfaces;
using Dating.Domain.Models;
using Dating.Infrastructure.DataBase;

namespace Dating.Infrastructure.EFRepositories
{
    public class UserImageRepository : BaseRepository<UserImage>, IRepository<UserImage>
    {
        public UserImageRepository(DataBaseContext context) : base(context, (i) => i.Images)
        {
        }

        public async Task<UserImage> Update(UserImage item)
        {
            var oldImage = await GetById(item.Id);

            oldImage.Path = item.Path;

            context.SaveChanges();

            return oldImage;
        }
    }
}
