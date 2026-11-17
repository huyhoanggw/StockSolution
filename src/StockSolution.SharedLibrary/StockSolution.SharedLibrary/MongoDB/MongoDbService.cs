using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.MongoDB
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDbSettings:MongoDbConnectionString"]);
            _database = client.GetDatabase(config["MongoDbSettings:MongoDbName"]);
        }
        public IMongoDatabase Database { get { return _database; } }
    }
}
