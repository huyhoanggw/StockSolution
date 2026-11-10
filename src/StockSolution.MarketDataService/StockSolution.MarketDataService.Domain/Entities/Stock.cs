using Microsoft.VisualBasic;
using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
