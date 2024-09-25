namespace Dating.Domain.Models
{
    public enum StatusRelationship
    {
        Onesided,
        Mutual,
        Refused
    }

    public class LocalizationLanguage
    {
        private LocalizationLanguage(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static LocalizationLanguage Russian { get; } = new LocalizationLanguage("ru");

        public static LocalizationLanguage English { get; } = new LocalizationLanguage("en");
    }
    /*
    public enum Gender
    {
        Male,
        Female
    }*/

    /*public enum SexOrientation
    {
        Heterosexual,
        Homosexual,
        Bisexual
    }*/

    /*public enum ZodiacSign
    {
        Aquarius,
        Pisces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn,
    }*/

    /*public enum ColorEyes
    {
        Brown,
        Blue,
        Green,
        Grey,
        Another
    }*/

    /*public enum HairColor
    {
        Brunette,
        BrownHaired,
        Blond,
        Redhead
    }*/
}
