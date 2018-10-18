using MassTransit;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace OrderApproval
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configure();

            var bus = GlobalConfiguration.ServiceProvider.GetService<IBusControl>();

            bus.StartAsync().Wait();

            Console.WriteLine("OrderApproval Waiting..");
            Console.ReadLine();
        }
    }
}