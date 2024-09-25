using Dating.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dating.Domain.Models
{
    public class User : BaseModel, ISoftDeletable
    {
        #region Basic information

        public string Firstname { get; set; } = string.Empty;

        public long TelegramId { get; set; }

        public DateOnly Birthdate { get; set; }

        public long GenderId { get; set; }

        public virtual Gender Gender { get; set; }

        public long SexOrientationId { get; set; }

        public virtual SexOrientation SexOrientation { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public long CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<City> PartnerCities { get; set; }

        [NotMapped]
        private long[]? partnerCitiesIds;

        [NotMapped]
        public long[] PartnerCitiesIds
        {
            get
            {
                return partnerCitiesIds ?? PartnerCities.Select(i => i.Id).ToArray();
            }
            set
            {
                partnerCitiesIds = value;
            }
        }

        public string BaseImageName { get; set; } = string.Empty;

        public virtual ICollection<UserImage> UserImages { get; set; }

        [NotMapped]
        private long[]? userImagesIds;

        [NotMapped]
        public long[] UserImagesIds
        {
            get
            {
                return userImagesIds ?? UserImages.Select(i => i.Id).ToArray();
            }
            set
            {
                userImagesIds = value;
            }
        }

        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Relationship> AsInitiatorRelationships { get; set; }

        public virtual ICollection<Relationship> AsResponderRelationships { get; set; }

        //public ICollection<Gender> InterestedGenders { get; set; }

        #endregion

        #region Extra information

        public string? Surname { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public int? MinPartnerHeight { get; set; }

        public int? MaxPartnerHeight { get; set; }

        public int? MinPartnerWeight { get; set; }

        public int? MaxPartnerWeight { get; set; }

        public int? MinPartnerYear { get; set; }

        public int? MaxPartnerYear { get; set; }

        public virtual ICollection<ZodiacSign> PartnerZodiacSigns { get; set; }

        [NotMapped]
        private long[]? partnerZodiacSignsIds;

        [NotMapped]
        public long[] PartnerZodiacSignsIds
        {
            get
            {
                return partnerZodiacSignsIds ?? PartnerZodiacSigns.Select(i => i.Id).ToArray();
            }
            set
            {
                partnerZodiacSignsIds = value;
            }
        }

        public long? ColorEyesId { get; set; }

        public virtual EyesColor? EyesColor { get; set; }

        public virtual ICollection<EyesColor> PartnerEyesColors { get; set; }

        [NotMapped]
        private long[]? partnerEyesColorsIds;

        [NotMapped]
        public long[] PartnerEyesColorsIds
        {
            get
            {
                return partnerEyesColorsIds ?? PartnerEyesColors.Select(i => i.Id).ToArray();
            }
            set
            {
                partnerEyesColorsIds = value;
            }
        }

        public long? HairColorId { get; set; }

        public virtual HairColor? HairColor { get; set; }

        public virtual ICollection<HairColor> PartnerHairColors { get; set; }

        [NotMapped]
        private long[]? partnerHairColorsIds;

        [NotMapped]
        public long[] PartnerHairColorsIds
        {
            get
            {
                return partnerHairColorsIds ?? PartnerHairColors.Select(i => i.Id).ToArray();
            }
            set
            {
                partnerHairColorsIds = value;
            }
        }

        public virtual ICollection<Tag> Tags { get; set; }

        [NotMapped]
        private long[]? tagsIds;

        [NotMapped]
        public long[] TagsIds
        {
            get
            {
                return tagsIds ?? Tags.Select(i => i.Id).ToArray();
            }
            set
            {
                tagsIds = value;
            }
        }

        public virtual ICollection<Language> Languages { get; set; }

        [NotMapped]
        private long[]? languagesIds;

        [NotMapped]
        public long[] LanguagesIds
        {
            get
            {
                return languagesIds ?? Languages.Select(i => i.Id).ToArray();
            }
            set
            {
                languagesIds = value;
            }
        }

        #endregion

        public DateTime? DeletedAt { get; set; }
    }
}
