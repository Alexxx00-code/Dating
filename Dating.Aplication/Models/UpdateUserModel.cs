namespace Dating.Aplication.Models
{
    public class UpdateUserModel
    {
        public long[] PartnerCitiesIds { get; set; }

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

        public long[] PartnerZodiacSignsIds { get; set; }

        public long? ColorEyesId { get; set; }

        public long[] PartnerEyesColorsIds { get; set; }

        public long? HairColorId { get; set; }

        public long[] PartnerHairColorsIds { get; set; }

        public long[] TagsIds { get; set; }

        public long[] LanguagesIds { get; set; }
    }
}
