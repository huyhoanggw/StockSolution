using MongoDB.Driver;
using StockSolution.MarketDataService.Application.IRepository;
using StockSolution.MarketDataService.Domain.Entities;
using StockSolution.SharedLibrary.BaseRepository;
using StockSolution.SharedLibrary.Interfaces;
using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Infrastructure.Repositories
{
    public class StockPriceRepository : BaseRepositoryForMongoDb<StockPrice>, IStockPriceRepository
    {
        public StockPriceRepository(MongoDbService mongodb) : base(mongodb)
        {
        }

        public async Task<StockPrice> GetLatestStockPriceBySymbolAsync(string symbol)
        {
            var filter = Builders<StockPrice>.Filter.Where(x => x.Symbol.Equals(symbol));
            return await _collection.Find(filter).SortByDescending(x => x.Timestamp).FirstOrDefaultAsync();
        }
        public async Task UpsertAsync(StockPrice stockPrice)
        {
            var filter = Builders<StockPrice>.Filter.Eq(x => x.Symbol, stockPrice.Symbol);
            var update = Builders<StockPrice>.Update
                .Set(x => x.LastPrice, stockPrice.LastPrice)
                .Set(x => x.Timestamp, stockPrice.Timestamp)
                .Set(x => x.TotalVolume, stockPrice.TotalVolume)
                .Set(x => x.OpenPrice, stockPrice.OpenPrice)
                .Set(x => x.HighestPrice, stockPrice.HighestPrice)
                .Set(x => x.LowestPrice, stockPrice.LowestPrice)
                .Set(x => x.Change, stockPrice.Change)
                .Set(x => x.ChangePercent, stockPrice.ChangePercent)
                .Set(x => x.Timestamp, stockPrice.Timestamp)
                .Set(x => x.UpdateAt, DateTime.UtcNow);
            await _collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }
    }
}
