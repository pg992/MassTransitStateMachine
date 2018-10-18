using Contracts;
using MassTransit;
using System.Threading.Tasks;

namespace OrderApproval
{
    public class FaultConsumer : IConsumer<Fault<IApproveOrder>>
    {
        public Task Consume(ConsumeContext<Fault<IApproveOrder>> context)
        {
            return context.Publish(new OrderRejected { Text = context.Message.Message.Text, CorrelationId = context.CorrelationId.Value });
        }
    }
}