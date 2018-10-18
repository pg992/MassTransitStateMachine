using MassTransit;
using System;

namespace Contracts
{
    public interface IOrderApproved : CorrelatedBy<Guid>
    {
        string Text { get; set; }
    }
}