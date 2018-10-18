using Contracts;
using System;

namespace TestSubscriber
{
    public class ApproveOrder : IApproveOrder
    {
        public string Text { get; set; }
        public Guid CorrelationId { get; set; }
    }
}