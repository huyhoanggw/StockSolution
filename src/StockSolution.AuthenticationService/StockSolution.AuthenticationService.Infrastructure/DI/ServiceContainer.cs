using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockSolution.AuthenticationService.Application.IRepositories.Interfaces;
using StockSolution.AuthenticationService.Application.Services.Interfaces;
using StockSolution.AuthenticationService.Infrastructure.Database;
using StockSolution.AuthenticationService.Infrastructure.Database.Seeding;
using StockSolution.AuthenticationService.Infrastructure.Helpers;
using StockSolution.AuthenticationService.Infrastructure.Repositories;
using StockSolution.SharedLibrary.DI;
using StockSolution.SharedLibrary.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Infrastructure.DI
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbcontext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            service.AddSharedServices(configuration, configuration["MySeriLog:FileName"]!);
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IPermissionRepository, PermissionRepository>();
            service.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            service.AddScoped<IUserRoleRepository, UserRoleRepository>();
            return service;
        }
        public static async Task<IApplicationBuilder> UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSharedPolicies();
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbcontext>();
                await ApplicationDbcontextSeeding.Seeding(dbContext);
                await AddPermissionForAdmin.AddAsync(dbContext);
                await AddPermissionForTrader.AddAsync(dbContext);
                LogException.LogToFile("Seeding completed successfully");
            }
            return app;
        }
    }
}
