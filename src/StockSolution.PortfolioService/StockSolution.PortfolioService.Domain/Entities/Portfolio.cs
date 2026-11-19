using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Domain.Entities
{
    public class Portfolio : SharedLibrary.SqlServer.BaseEntity
    {
        public Guid UserId { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal CashBalance { get; set; }

        public ICollection<PortfolioHolding> Holdings { get; set; } = new List<PortfolioHolding>();
        public ICollection<PortfolioTransaction> Transactions { get; set; } = new List<PortfolioTransaction>();
    }
}
