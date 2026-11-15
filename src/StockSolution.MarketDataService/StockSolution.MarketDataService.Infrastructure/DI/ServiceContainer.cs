using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockSolution.MarketDataService.Application.IRepository;
using StockSolution.MarketDataService.Infrastructure.Repositories;
using StockSolution.SharedLibrary.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Infrastructure.DI
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddSharedServices(config, config["MySeriLog:FileName"]!);
            services.AddScoped<IStockPriceRepository, StockPriceRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            return services;
        }
        public static IApplicationBuilder UseInfrastructurePolicies(this IApplicationBuilder app)
        {
            app.UseSharedPolicies();
            return app;
        }
    }
}
