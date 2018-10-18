using System;
using Contracts;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace TestPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configure();

            var bus = GlobalConfiguration.ServiceProvider.GetService<IBusControl>();

            var text = string.Empty;

            while (text != "quit")
            {
                Console.Write("Enter an order: ");
                text = Console.ReadLine();

                var message = new Order
                {
                    What = text,
                    When = DateTime.Now,
                    CorrelationId = Guid.NewGuid()
                };

                bus.Publish<IOrder>(message).Wait();
            }
        }
    }
}