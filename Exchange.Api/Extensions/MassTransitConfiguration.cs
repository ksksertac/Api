using Exchange.Api.Consumers;
using MassTransit;

namespace Exchange.Api.Extensions
{
    public static class MassTransitExtension
    {
        public static void MassTransitConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<InstructionNotificationEventConsumer>().Endpoint(e => e.Name = "notification_queue");
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration.GetSection("RabbitMqUrl").Value,
                        Configuration.GetSection("RabbitMq:VirtualHost").Value, h =>
                        {
                            h.Username(Configuration.GetSection("RabbitMq:Username").Value);
                            h.Password(Configuration.GetSection("RabbitMq:Password").Value);
                        });
                    cfg.ConfigureEndpoints(context);

                });
            });
            services.AddMassTransitHostedService();
        }
    }
}