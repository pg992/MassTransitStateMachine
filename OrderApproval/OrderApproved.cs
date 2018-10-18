using Contracts;
using System;

namespace OrderApproval
{
    public class OrderApproved : IOrderApproved
    {
        public string Text { get; set; }
        public Guid CorrelationId { get; set; }
    }
}