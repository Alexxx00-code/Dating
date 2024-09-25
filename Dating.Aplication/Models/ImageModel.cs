using Dating.Domain.Models;

namespace Dating.Aplication.Models
{
    public class ImageModel
    {
        public long Id { get; set; }

        public static readonly Func<UserImage, ImageModel> ToModel = (image) => 
        {
            return new ImageModel { Id = image.Id };
        };
 
    }
}
