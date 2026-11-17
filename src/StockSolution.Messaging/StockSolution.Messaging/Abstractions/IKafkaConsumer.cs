using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.Messaging.Abstractions
{
    public interface IKafkaConsumer
    {
        Task ConsumerAsync(CancellationToken cancellationToken);
    }
}
