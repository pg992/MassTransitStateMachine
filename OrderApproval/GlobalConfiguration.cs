using Microsoft.Extensions.DependencyInjection;
using System;

namespace OrderApproval
{
    public class GlobalConfiguration
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Configure()
        {
            var startup = new Startup();
            var serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}