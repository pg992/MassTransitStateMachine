using MassTransit;
using System;

namespace Contracts
{
    public interface IOrder : CorrelatedBy<Guid>
    {
        string What { get; }
        DateTime When { get; }
    }
}