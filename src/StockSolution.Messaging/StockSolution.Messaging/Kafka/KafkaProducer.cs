using Confluent.Kafka;
using StockSolution.Messaging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.Messaging.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        public IProducer<string, string> _producer;
        public KafkaProducer()
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }
        public Task ProducerRawAsync<T>(string topic, Guid EventId, string value)
        {
            var kafkaMessage = new Message<string, string> { Key = EventId.ToString(), Value = value };
            return _producer.ProduceAsync(topic, kafkaMessage);
        }
    }
}
