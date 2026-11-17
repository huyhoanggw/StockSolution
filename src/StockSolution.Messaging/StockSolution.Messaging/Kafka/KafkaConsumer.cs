using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockSolution.Messaging.Abstractions;
using StockSolution.SharedLibrary.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockSolution.Messaging.Kafka
{
    public class KafkaConsumer : BackgroundService, IKafkaConsumer
    {
        private readonly IEventHandler _handle;
        public IConsumer<string, string> _consumer;
        public KafkaConsumer(string[] topics, string groupId, IEventHandler handle)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe(topics);
            _handle = handle;
        }
        public async Task ConsumerAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {


                    var consumerResult = _consumer.Consume(cancellationToken);
                    if (consumerResult is null) continue;
                    // var message = JsonSerializer.Deserialize<T>(consumerResult.Message.Value);
                    await _handle.HandleAsync(consumerResult, cancellationToken);
                    _consumer.Commit(consumerResult);

                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                LogException.LogToFile("Kafka consumer is stopping");
                throw;
            }
            finally
            {
                _consumer.Close();
                _consumer.Dispose();
            }

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(async () =>
            {
                await ConsumerAsync(stoppingToken);
            }, stoppingToken);
        }
    }
}
