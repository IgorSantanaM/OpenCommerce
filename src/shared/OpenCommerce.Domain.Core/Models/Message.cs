namespace OpenCommerce.Domain.Core.Models
{
    public record Message<TId> where TId : notnull
    {
        public string MessageType { get; protected set; } = string.Empty;
        public TId? AggregateId { get; protected set; }

        public Message(TId aggregateId)
        {
            AggregateId = aggregateId;
            MessageType = GetType().Name;
        }
    }
}
