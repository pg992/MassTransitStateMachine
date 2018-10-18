using MassTransit;
using System;

namespace Contracts
{
    public interface IPick : CorrelatedBy<Guid>
    {
        string What { get; set; }
    }
}