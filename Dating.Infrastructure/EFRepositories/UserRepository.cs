using Dating.Domain.Interfaces;
using Dating.Domain.Models;
using Dating.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Dating.Infrastructure.EFRepositories
{
    public class UserRepository : BaseRepository<User> , IRepository<User>
    {
        public UserRepository(DataBaseContext context) : base(context, (i) => i.Users)
        {
        }

        public override async Task<User> Create(User user)
        {
            foreach (var item in context.Images.Where(i => user.UserImagesIds.Contains(i.Id)))
            {
                user.UserImages.Add(item);
            }

            foreach (var item in context.Cities.Where(i => user.PartnerCitiesIds.Contains(i.Id)))
            {
                user.PartnerCities.Add(item);
            }

            foreach (var item in context.ZodiacSigns.Where(i => user.PartnerZodiacSignsIds.Contains(i.Id)))
            {
                user.PartnerZodiacSigns.Add(item);
            }

            foreach (var item in context.EyesColors.Where(i => user.PartnerEyesColorsIds.Contains(i.Id)))
            {
                user.PartnerEyesColors.Add(item);
            }

            foreach (var item in context.HairColors.Where(i => user.PartnerHairColorsIds.Contains(i.Id)))
            {
                user.PartnerHairColors.Add(item);
            }

            foreach (var item in context.Tags.Where(i => user.TagsIds.Contains(i.Id)))
            {
                user.Tags.Add(item);
            }

            foreach (var item in context.Languages.Where(i => user.LanguagesIds.Contains(i.Id)))
            {
                user.Languages.Add(item);
            }

            return await base.Create(user);
        }

        public async Task<bool> Update(User user)
        {
            var oldUser = context.Users.Where(i => i.Id == user.Id)
                .Include(i => i.PartnerCities)
                .Include(i => i.PartnerZodiacSigns)
                .Include(i => i.PartnerEyesColors)
                .Include(i => i.PartnerHairColors)
                .Include(i => i.Tags)
                .Include(i => i.Languages)
                .FirstOrDefault();

            #region PersonalInformation
            oldUser.Firstname = user.Firstname;
            oldUser.Birthdate = user.Birthdate;
            oldUser.GenderId = user.GenderId;
            oldUser.SexOrientationId = user.SexOrientationId;
            oldUser.Surname = user.Surname;
            oldUser.Height = user.Height;
            oldUser.Weight = user.Weight;
            oldUser.BaseImageName = user.BaseImageName;
            UpdateManyToMany(oldUser.UserImages, context.Images, user.UserImagesIds);
            oldUser.Description = user.Description;
            oldUser.ColorEyesId = user.ColorEyesId;
            oldUser.HairColorId = user.HairColorId;
            #endregion

            #region Location
            oldUser.Latitude = user.Latitude;
            oldUser.Longitude = user.Longitude;
            oldUser.CityId = user.CityId;
            #endregion

            #region PartnerParameters
            UpdateManyToMany(oldUser.PartnerCities, context.Cities, user.PartnerCitiesIds);
            oldUser.MinPartnerHeight = user.MinPartnerHeight;
            oldUser.MaxPartnerHeight = user.MaxPartnerHeight;
            oldUser.MinPartnerWeight = user.MinPartnerWeight;
            oldUser.MaxPartnerWeight = user.MaxPartnerWeight;
            oldUser.MinPartnerYear = user.MinPartnerYear;
            oldUser.MaxPartnerYear = user.MaxPartnerYear;
            UpdateManyToMany(oldUser.PartnerZodiacSigns, context.ZodiacSigns, user.PartnerZodiacSignsIds);
            UpdateManyToMany(oldUser.PartnerEyesColors, context.EyesColors, user.PartnerEyesColorsIds);
            UpdateManyToMany(oldUser.PartnerHairColors, context.HairColors, user.PartnerHairColorsIds);
            UpdateManyToMany(oldUser.Tags, context.Tags, user.TagsIds);
            UpdateManyToMany(oldUser.Languages, context.Languages, user.LanguagesIds);
            #endregion
            
            return await context.SaveChangesAsync() > 0;
        }

        private void UpdateManyToMany<T>(ICollection<T> values, DbSet<T> collection, long[] ids) where T : BaseModel
        {
            values.Clear();

            foreach (var item in collection.Where(i => ids.Contains(i.Id)))
            {
                values.Add(item);
            }
        }
    }
}
