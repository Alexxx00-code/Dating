using Dating.Domain.Interfaces;

namespace Dating.Domain.Models
{
    public class Relationship : BaseModel, ISoftDeletable
    {
        public long FirstUserId { get; set; }

        public virtual User FirstUser { get; set; }

        public long SecondUserId { get; set; }

        public virtual User SecondUser { get; set; }

        public StatusRelationship Status { get; set; }

        public DateTime OnesidedDateTime { get; set; }

        public DateTime MutualDateTime { get; set; }

        public DateTime RefusedDateTime { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
