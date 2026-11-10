using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using StockSolution.SharedLibrary.Interfaces;
using StockSolution.SharedLibrary.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.BaseRepository
{
    public class BaseRepositoryForMongoDb<T> : IGenericInterface<T> where T : BaseEntity
    {
        IMongoCollection<T> _collection;
        public BaseRepositoryForMongoDb(MongoDbService mongodb)
        {
            _collection = mongodb.Database.GetCollection<T>(typeof(T).Name);
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var filter = Builders<T>.Filter.Eq("Id", Id);
            var result = await _collection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }

        public async Task<T> FindByIdAsync(Guid Id)
        {
            var filter = Builders<T>.Filter.Eq("Id", Id);
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _collection.FindAsync(_ => true);
            return await result.ToListAsync();
        }

        public async Task<T> GetByAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var filter = Builders<T>.Filter.Where(predicate);
            return await _collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            var result = await _collection.ReplaceOneAsync(filter, entity);
            return result.ModifiedCount > 0 ? true : false;
        }
    }
}
