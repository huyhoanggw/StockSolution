using StockSolution.PortfolioService.Domain.Entities.Enum;
using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Domain.Entities
{
    public class PortfolioTransaction : SharedLibrary.SqlServer.BaseEntity
    {
        public Guid PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public decimal Price { get; set; }
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public TransactionType TransactionType { get; set; }

    }
}
