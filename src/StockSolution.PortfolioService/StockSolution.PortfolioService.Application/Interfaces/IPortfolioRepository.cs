using StockSolution.PortfolioService.Domain.Entities;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Application.Interfaces
{
    public interface IPortfolioRepository : IGenericInterface<Portfolio>
    {
        public Task<IEnumerable<Portfolio>> GetPortfoliosByUserId(Guid UserId);

    }
}
