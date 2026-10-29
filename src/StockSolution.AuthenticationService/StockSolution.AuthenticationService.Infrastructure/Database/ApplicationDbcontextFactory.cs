using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Database
{
    public class ApplicationDbcontextFactory : IDesignTimeDbContextFactory<ApplicationDbcontext>
    {
        public ApplicationDbcontext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("../StockSolution.AuthenticationService.Presentation/appsettings.json").Build();
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>();
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new ApplicationDbcontext(options.Options);

        }
    }
}
