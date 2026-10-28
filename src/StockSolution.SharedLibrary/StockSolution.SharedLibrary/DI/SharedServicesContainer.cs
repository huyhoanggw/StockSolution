using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using StockSolution.SharedLibrary.DI.Mongo;
using StockSolution.SharedLibrary.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.DI
{
    public static class SharedServicesContainer
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration config, string fileName)
        {
            MongoDbExtensions.AddMongoDb(services, config);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File($"logs/{fileName}", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            services.AddSerilog();
            // add jwt
            JWTAuthenticationScheme.AddJWTAuthenticationScheme(services, config);
            return services;
        }
        public static IApplicationBuilder UseSharedPolicies(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalException>();
            app.UseMiddleware<ListenToOnlyApiGateway>();
            return app;
        }
    }
}
