using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace PickService
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
            var busClient = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                var host = config.Host(new Uri(Configuration["RabbitMQ:ConnectionString"]), h =>
                {
                    h.Username(Configuration["RabbitMQ:Username"]);
                    h.Password(Configuration["RabbitMQ:Password"]);
                });

                config.ReceiveEndpoint(host, "PickService", ep =>
                {
                    ep.Consumer(() => new PickConsumer());
                });
            });

            services.AddSingleton(busClient);
        }
    }
}
