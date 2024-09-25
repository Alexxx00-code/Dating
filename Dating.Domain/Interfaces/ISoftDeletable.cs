namespace Dating.Domain.Interfaces
{
    public interface ISoftDeletable
    {
        public DateTime? DeletedAt { get; set; }
    }
}
