using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.Database
{
    public class ApplicationDbcontextFactory : IDesignTimeDbContextFactory<ApplicationDbcontext>
    {
        public ApplicationDbcontext CreateDbContext(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();

            var configPath = Path.GetFullPath(
                "../StockSolution.AuthenticationService.Presentation/appsettings.json",
                currentDir
            );


            var config = new ConfigurationBuilder()
                .AddJsonFile(configPath, optional: false).AddUserSecrets("5b31f3a4-48ed-4d33-862b-2cf1b9fa79fe")
                .Build();
            var options = new DbContextOptionsBuilder<ApplicationDbcontext>();
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"), sqloptions => sqloptions.EnableRetryOnFailure(10));
            return new ApplicationDbcontext(options.Options);

        }
    }
}
