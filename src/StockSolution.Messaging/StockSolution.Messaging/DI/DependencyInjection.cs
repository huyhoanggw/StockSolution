using Microsoft.Extensions.DependencyInjection;
using StockSolution.Messaging.Abstractions;
using StockSolution.Messaging.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.Messaging.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKafka(this IServiceCollection services)
        {
            services.AddSingleton<IKafkaProducer, KafkaProducer>();
            services.AddSingleton<IKafkaConsumer, KafkaConsumer>();
            services.AddHostedService<KafkaConsumer>();
            return services;
        }
    }
}
