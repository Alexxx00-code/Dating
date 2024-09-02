namespace Dating.Domain.Models
{
    public class UserImage : BaseModel
    {
        public string Path { get; set; } = string.Empty;

        public long UserId { get; set; }
    }
}
