using Dating.Domain.Models;

namespace Dating.Aplication.Models
{
    public class CreateUserModel
    {
        public string Firstname { get; set; } = string.Empty;

        public DateOnly Birthdate { get; set; }

        public long GenderId { get; set; }

        public long SexOrientationId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string BaseImagePath { get; set; }
    }
}
