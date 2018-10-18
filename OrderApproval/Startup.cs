using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace OrderApproval
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"Config/appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var retries = 3;
            var interval = 2;

            var busClient = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                var host = config.Host(new Uri(Configuration["RabbitMQ:ConnectionString"]), h =>
                {
                    h.Username(Configuration["RabbitMQ:Username"]);
                    h.Password(Configuration["RabbitMQ:Password"]);
                });

                config.ReceiveEndpoint(host, "OrderApprover", ep =>
                {
                    ep.AutoDelete = false;
                    ep.Durable = true;
                    ep.SetQueueArgument("x-expires", null);
                    ep.PrefetchCount = 1;
                    ep.UseScheduledRedelivery(retryCfg => retryCfg.Interval(retries, TimeSpan.FromSeconds(interval)));
                    ep.Consumer(() => new ApproveConsumer());
                    ep.Consumer(() => new FaultConsumer());
                });

                config.UseInMemoryScheduler();
            });
            
            services.AddSingleton(busClient);
        }
    }
}