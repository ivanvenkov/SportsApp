using Domain.Application;
using Domain.Facotry;
using Domain.Kafka;
using KafkaService;
using KafkaService.Services.Common;
using Microsoft.Extensions.DependencyInjection;

namespace FootballSolutionMS.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ResolveServices(this IServiceCollection services)
        {
            services.AddScoped<IFactory, Factory>();
            services.AddScoped<IPersonManager, PersonManager>();
            return services;
        }

        public static IServiceCollection ResolveKafka(this IServiceCollection services)
        {
            services.AddScoped<IKafkaServiceFactory, KafkaServiceFactory>();
            services.AddScoped<IKafkaConsumer, FootballKafkaConsumer>();
            services.AddHostedService<KafkaConsumerService>();
            return services;
        }
    }
}
