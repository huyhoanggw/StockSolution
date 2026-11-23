using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Infrastructure.Database
{
    public class PortfolioDbcontextFactory : IDesignTimeDbContextFactory<PortfolioDbcontext>
    {
        public PortfolioDbcontext CreateDbContext(string[] args)
        {
            var direct = Directory.GetCurrentDirectory();
            var fullpath = Path.GetFullPath("../StockSolution.PortfolioService.Presentation/appsettings.json", direct);

            var config = new ConfigurationBuilder().AddJsonFile(fullpath).AddUserSecrets("9e9f396d-7cc3-427d-8262-31246fa9582f").Build();
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new PortfolioDbcontext(options.Options);
        }
    }
}
