using Contracts;
using System;

namespace TestPublisher
{
    public class Order : IOrder
    {
        public string What { get; set; }
        public DateTime When { get; set; }
        public Guid CorrelationId { get; set; }
    }
}