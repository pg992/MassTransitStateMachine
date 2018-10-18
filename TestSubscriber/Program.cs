using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace TestSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configure();
            var bus = GlobalConfiguration.ServiceProvider.GetService<IBusControl>();

            bus.StartAsync().Wait();

            Console.WriteLine("Saga Waiting..");
            Console.ReadLine();
        }
    }
}