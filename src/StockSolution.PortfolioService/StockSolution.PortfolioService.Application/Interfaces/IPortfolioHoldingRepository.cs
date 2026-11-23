using StockSolution.PortfolioService.Domain.Entities;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Application.Interfaces
{
    public interface IPortfolioHoldingRepository : IGenericInterface<PortfolioHolding>
    {
        public Task<IEnumerable<PortfolioHolding>> GetPortfolioHoldingsByPortfolioId(Guid PortfolioId);
        public Task<decimal> GetFieldsQuanlityShares(Guid Id);
        public Task<decimal> GetAveragePirce(Guid Id);
        public Task<decimal> CheckCurrentPrice(string Symbol);
    }
}
