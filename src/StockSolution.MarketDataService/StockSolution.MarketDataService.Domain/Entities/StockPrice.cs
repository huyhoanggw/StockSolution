using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Domain.Entities
{
    public class StockPrice : BaseEntity
    {

        public string Symbol { get; set; } = null!;

        public decimal LastPrice { get; set; }

        public decimal Change { get; set; }

        public decimal ChangePercent { get; set; }

        public decimal ReferencePrice { get; set; }

        public decimal CeilingPrice { get; set; }

        public decimal FloorPrice { get; set; }

        public decimal OpenPrice { get; set; }

        public decimal HighestPrice { get; set; }

        public decimal LowestPrice { get; set; }

        public long TotalVolume { get; set; }

        public DateTime TradingDate { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
