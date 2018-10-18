using MassTransit;
using System;

namespace Contracts
{
    public interface IApproveOrder : CorrelatedBy<Guid>
    {
        string Text { get; set; }
    }
}