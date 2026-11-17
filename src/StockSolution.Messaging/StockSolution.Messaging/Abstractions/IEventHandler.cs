using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.Messaging.Abstractions
{
    public interface IEventHandler
    {
        Task HandleAsync(ConsumeResult<string, string> consumeResult, CancellationToken cancellationToken);
    }
}
