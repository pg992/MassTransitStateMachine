using Contracts;
using System;

namespace TestSubscriber
{
    public class OrderPick : IPick
    {
        public string What { get; set; }

        public Guid CorrelationId { get; set; }
    }
}