using Contracts;
using System;

namespace OrderApproval
{
    public class OrderRejected : IOrderRejected
    {
        public string Text { get; set; }
        public Guid CorrelationId { get; set; }
    }
}