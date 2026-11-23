using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Domain.Entities
{
    public class PortfolioHolding : SharedLibrary.SqlServer.BaseEntity
    {
        public Guid PorfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal AverageCost { get; set; }
    }
}
