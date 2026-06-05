namespace OpenCommerce.Domain.Core.Models
{
    public class Event<TId> : Message<TId> where TId : notnull
    {
        public DateTime TimeStamp { get; init; }
        public Event(TId aggregateId) : base(aggregateId)
        {
            TimeStamp = DateTime.UtcNow;
        }
    }
}
