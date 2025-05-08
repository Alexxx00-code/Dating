namespace Dating.Aplication.Models
{
    public class ImageModel
    {
        public long Id { get; set; }

        public string Url => $"api/Image/{Id}";

        public bool FaceVerification { get; set; }
    }
}
