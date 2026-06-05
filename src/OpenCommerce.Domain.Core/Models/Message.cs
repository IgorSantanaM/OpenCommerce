using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCommerce.Domain.Core.Models
{
    public class Message<TId> where TId : notnull
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
