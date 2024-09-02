namespace Dating.Domain.Models
{
    public class User : BaseModel, ISoftDeletable
    {
        #region Basic information

        public string Firstname { get; set; } = string.Empty;

        public long TelegramId { get; set; }

        public DateTime Birthdate { get; set; }

        public long GenderId { get; set; }

        public virtual Gender Gender { get; set; }

        public long SexOrientationId { get; set; }

        public virtual SexOrientation SexOrientation { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public long CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<City> PartnerCities { get; set; }

        public string BaseImageName { get; set; } = string.Empty;

        public virtual ICollection<UserImage> UserImages { get; set; }

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

        public long? ColorEyesId { get; set; }

        public virtual EyesColor? EyesColor { get; set; }

        public virtual ICollection<EyesColor> PartnerEyesColors { get; set; }

        public long? HairColorId { get; set; }

        public virtual HairColor? HairColor { get; set; }

        public virtual ICollection<HairColor> PartnerHairColors { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        #endregion

        public DateTime? DeletedAt { get; set; }
    }
}
