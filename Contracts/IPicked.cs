using MassTransit;
using System;

namespace Contracts
{
    public interface IPicked : CorrelatedBy<Guid>
    {
        string Text { get; set; }
    }
}