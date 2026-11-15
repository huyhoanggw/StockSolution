using StockSolution.MarketDataService.Domain.Entities;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.IRepository
{
    public interface IStockRepository : IGenericInterface<Stock>
    {
        public Task<Stock> GetStockBySymbolAsync(string symbol);
        public Task UpsertAsync(Stock stock);


    }
}
