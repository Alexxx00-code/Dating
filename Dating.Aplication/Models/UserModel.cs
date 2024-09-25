using Dating.Domain.Models;

namespace Dating.Aplication.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Firstname { get; set; } = string.Empty;

        public DateOnly Birthdate { get; set; }

        public ParameterModel Gender { get; set; }

        public ParameterModel SexOrientation { get; set; }

        public ParameterModel City { get; set; }

        public List<ParameterModel> PartnerCities { get; set; }

        public List<ImageModel> UserImagesPathes { get; set; }

        public string Description { get; set; } = string.Empty;

        public string? Surname { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public int? MinPartnerHeight { get; set; }

        public int? MaxPartnerHeight { get; set; }

        public int? MinPartnerWeight { get; set; }

        public int? MaxPartnerWeight { get; set; }

        public int? MinPartnerYear { get; set; }

        public int? MaxPartnerYear { get; set; }

        public List<ParameterModel> PartnerZodiacSigns { get; set; }

        public ParameterModel? EyesColor { get; set; }

        public List<ParameterModel> PartnerEyesColors { get; set; }

        public ParameterModel? HairColor { get; set; }

        public List<ParameterModel> PartnerHairColors { get; set; }

        public List<ParameterModel> Tags { get; set; }

        public List<ParameterModel> Languages { get; set; }

        public static Func<User, UserModel> ToModel = (user) =>
        {
            return new UserModel
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Birthdate = user.Birthdate,
                Gender = ParameterModel.ToModel(user.Gender),
                SexOrientation = ParameterModel.ToModel(user.SexOrientation),
                City = ParameterModel.ToModel(user.City),
                PartnerCities = user.PartnerCities.Select(i => ParameterModel.ToModel(i)).ToList(),
                UserImagesPathes = user.UserImages.Select(i => ImageModel.ToModel(i)).ToList(),
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
                PartnerZodiacSigns = user.PartnerZodiacSigns.Select(i => ParameterModel.ToModel(i)).ToList(),
                EyesColor = user.EyesColor != null ? ParameterModel.ToModel(user.EyesColor) : null,
                PartnerEyesColors = user.PartnerEyesColors.Select(i => ParameterModel.ToModel(i)).ToList(),
                HairColor = user.HairColor != null ? ParameterModel.ToModel(user.HairColor) : null,
                PartnerHairColors = user.PartnerHairColors.Select(i => ParameterModel.ToModel(i)).ToList(),
                Tags = user.Tags.Select(i => ParameterModel.ToModel(i)).ToList(),
                Languages = user.Languages.Select(i => ParameterModel.ToModel(i)).ToList()
            };
        };
    }
}
