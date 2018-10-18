using Contracts;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApproval
{
    public class ApproveConsumer : IConsumer<IApproveOrder>
    {
        private static int counter = 0;
        public Task Consume(ConsumeContext<IApproveOrder> context)
        {
            Console.WriteLine("Approving order {0}", context.Message.Text);
            Thread.Sleep(1000);
            counter++;
            //if(counter % 3 == 0)
            //{
            //    return context.Publish(new OrderApproved { Text = context.Message.Text, CorrelationId = context.CorrelationId.Value });
            //}
            //else
            //{
            //    throw new Exception("Petar");
            //}
            throw new Exception("Petar");
        }
    }
}