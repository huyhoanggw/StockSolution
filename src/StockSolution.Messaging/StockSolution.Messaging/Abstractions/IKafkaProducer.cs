using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.Messaging.Abstractions
{
    public interface IKafkaProducer
    {
        Task ProducerRawAsync<T>(string topic, Guid EventId, string value);
    }
}
