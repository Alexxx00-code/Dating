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
    }
}
