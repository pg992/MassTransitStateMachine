using Contracts;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PickService
{
    public class PickConsumer : IConsumer<IPick>
    {
        public Task Consume(ConsumeContext<IPick> context)
        {
            Console.WriteLine("Pick order {0}", context.Message.What);
            Thread.Sleep(1000);
            return context.Publish(new OrderPicked { CorrelationId = context.CorrelationId.Value, Text = context.Message.What });
        }
    }
}