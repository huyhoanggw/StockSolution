using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockSolution.SharedLibrary.Interfaces;
using StockSolution.SharedLibrary.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SqlServer.DI
{
    public static class SharedContainer
    {
        public static IServiceCollection AddSqlserverUnitOfWork<TContext>(this IServiceCollection services, IConfiguration config) where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            return services;
        }
    }
}
