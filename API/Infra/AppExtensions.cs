using MassTransit;
using RabbitMQ.API.Services;

namespace RabbitMQ.API.Infra;
internal static class AppExtensions
{
    public static void AddRabbitMQ(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<ConsumerService>();

            busConfigurator.UsingRabbitMq((context, config) =>
            {
                config.Host(new Uri(RabbitMqConfig.Host), host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
                config.ConfigureEndpoints(context);
            });

        });

    }
}