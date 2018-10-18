using MassTransit;
using System;

namespace Contracts
{
    public interface IOrderRejected : CorrelatedBy<Guid>
    {
        string Text { get; set; }
    }
}