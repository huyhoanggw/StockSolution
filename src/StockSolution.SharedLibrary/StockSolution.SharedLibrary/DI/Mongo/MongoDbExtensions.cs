using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.DI.Mongo
{
    public static class MongoDbExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbSetting>(config.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoClient>(options =>
            {
                var setting = options.GetRequiredService<IOptions<MongoDbSetting>>().Value;
                return new MongoClient(setting.ConnectionString);

            });
            services.AddSingleton<IMongoDatabase>(options =>
            {
                var setting = options.GetRequiredService<IOptions<MongoDbSetting>>().Value;
                var client = options.GetRequiredService<IMongoClient>();
                return client.GetDatabase(setting.DatabaseName);
            });
            return services;
        }
    }
}
