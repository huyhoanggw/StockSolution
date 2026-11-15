using MediatR;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Commands.StockPrice.UpsertStockPrice
{
    public class UpsertStockPriceCommand : IRequest<ReponseResult<bool>>
    {
        public string Symbol { get; set; } = null!;

        public decimal LastPrice { get; set; }

        public decimal Change { get; set; }

        public decimal ChangePercent { get; set; }

        public decimal OpenPrice { get; set; }

        public decimal HighestPrice { get; set; }

        public decimal LowestPrice { get; set; }

        public long TotalVolume { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
