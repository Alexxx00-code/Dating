namespace Dating.Domain.Models
{
    public abstract class BaseParameter : BaseModel
    {
        public string Name { get; set; } = string.Empty;
    }
}
