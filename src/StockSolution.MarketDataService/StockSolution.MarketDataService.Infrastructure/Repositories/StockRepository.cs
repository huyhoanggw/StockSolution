using MongoDB.Driver;
using StockSolution.MarketDataService.Application.IRepository;
using StockSolution.MarketDataService.Domain.Entities;
using StockSolution.SharedLibrary.BaseRepository;
using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Infrastructure.Repositories
{
    public class StockRepository : BaseRepositoryForMongoDb<Stock>, IStockRepository
    {
        public StockRepository(MongoDbService mongodb) : base(mongodb)
        {
        }

        public Task<Stock> GetStockBySymbolAsync(string symbol)
        {
            var filter = Builders<Stock>.Filter.Where(x => x.Symbol.Equals(symbol));
            return _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpsertAsync(Stock stock)
        {
            var filter = Builders<Stock>.Filter.Eq(x => x.Symbol, stock.Symbol);
            var update = Builders<Stock>.Update
                .Set(x => x.Name, stock.Name)
                .Set(x => x.Symbol, stock.Symbol)
                .Set(x => x.Exchange, stock.Exchange)
                .Set(x => x.UpdateAt, DateTime.UtcNow);
            await _collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }
    }
}
