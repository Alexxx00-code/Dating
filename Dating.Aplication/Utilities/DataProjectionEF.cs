using Dating.Aplication.Models;
using Dating.Domain.Models;

namespace Dating.Aplication.Utilities
{
    public static class DataProjectionEF
    {

        public static UserModel ToModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Birthdate = user.Birthdate,
                Gender = user.Gender.ToModel(),
                SexOrientation = user.SexOrientation.ToModel(),
                City = user.City.ToModel(),
                PartnerCities = user.PartnerCities.Select(i => i.ToModel()).ToList(),
                UserImagesPathes = user.UserImages.Select(i => i.ToModel()).ToList(),
                Description = user.Description,
                Surname = user.Surname,
                Weight = user.Weight,
                Height = user.Height,
                MinPartnerHeight = user.MinPartnerHeight,
                MaxPartnerHeight = user.MaxPartnerHeight,
                MinPartnerWeight = user.MinPartnerWeight,
                MaxPartnerWeight = user.MaxPartnerWeight,
                MinPartnerYear = user.MinPartnerYear,
                MaxPartnerYear = user.MaxPartnerYear,
                PartnerZodiacSigns = user.PartnerZodiacSigns.Select(i => i.ToModel()).ToList(),
                EyesColor = user.EyesColor.ToModelNull(),
                PartnerEyesColors = user.PartnerEyesColors.Select(i => i.ToModel()).ToList(),
                HairColor = user.HairColor.ToModelNull(),
                PartnerHairColors = user.PartnerHairColors.Select(i => i.ToModel()).ToList(),
                Tags = user.Tags.Select(i => i.ToModel()).ToList(),
                Languages = user.Languages.Select(i => i.ToModel()).ToList(),
            };
        }

        public static IQueryable<UserModel> ToModel(this IQueryable<User> users)
        {
            return users.Select(user => new UserModel
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Birthdate = user.Birthdate,
                Gender = user.Gender.ToModel(),
                SexOrientation = user.SexOrientation.ToModel(),
                City = user.City.ToModel(),
                PartnerCities = user.PartnerCities.Select(i => i.ToModel()).ToList(),
                UserImagesPathes = user.UserImages.Select(i => i.ToModel()).ToList(),
                Description = user.Description,
                Surname = user.Surname,
                Weight = user.Weight,
                Height = user.Height,
                MinPartnerHeight = user.MinPartnerHeight,
                MaxPartnerHeight = user.MaxPartnerHeight,
                MinPartnerWeight = user.MinPartnerWeight,
                MaxPartnerWeight = user.MaxPartnerWeight,
                MinPartnerYear = user.MinPartnerYear,
                MaxPartnerYear = user.MaxPartnerYear,
                PartnerZodiacSigns = user.PartnerZodiacSigns.Select(i => i.ToModel()).ToList(),
                EyesColor = user.EyesColor.ToModelNull(),
                PartnerEyesColors = user.PartnerEyesColors.Select(i => i.ToModel()).ToList(),
                HairColor = user.HairColor.ToModelNull(),
                PartnerHairColors = user.PartnerHairColors.Select(i => i.ToModel()).ToList(),
                Tags = user.Tags.Select(i => i.ToModel()).ToList(),
                Languages = user.Languages.Select(i => i.ToModel()).ToList(),
            });
        }

        public static IQueryable<ParameterModel> ToModel(this IQueryable<BaseParameter> parameters)
        {
            return parameters.Select(parameter => new ParameterModel
            {
                Id = parameter.Id,
                Name = parameter.Name
            });
        }

        public static ParameterModel ToModel(this BaseParameter parameter)
        {
            return new ParameterModel
            {
                Id = parameter.Id,
                Name = parameter.Name
            };
        }

        public static ParameterModel? ToModelNull(this BaseParameter? parameter)
        {
            return parameter != null ? new ParameterModel
            {
                Id = parameter.Id,
                Name = parameter.Name
            } : null;
        }
        public static IQueryable<ImageModel> ToModel(this IQueryable<UserImage> images)
        {
            return images.Select(image => new ImageModel
            {
                Id = image.Id
            });
        }

        public static ImageModel ToModel(this UserImage image)
        {
            return new ImageModel
            {
                Id = image.Id
            };
        }
    }
}
