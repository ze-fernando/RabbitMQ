using MassTransit;

namespace API.Infra
{
    internal static class AppExtensions
    {
        public static void AddRabbitMQ(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.UsingRabbitMq((context, config) =>
                {
                    config.Host(Configuration.RabbitMQHost);
                });

            });

        }
    }
}