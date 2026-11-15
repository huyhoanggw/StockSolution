using StockSolution.MarketDataService.Domain.Entities;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.IRepository
{
    public interface IStockPriceRepository : IGenericInterface<StockPrice>
    {
        public Task UpsertAsync(StockPrice stockPrice);
        public Task<StockPrice> GetLatestStockPriceBySymbolAsync(string symbol);

    }
}
