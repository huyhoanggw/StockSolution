
using StockSolution.AuthenticationService.Application.DI;
using StockSolution.AuthenticationService.Infrastructure.Database;
using StockSolution.AuthenticationService.Infrastructure.DI;

namespace StockSolution.AuthenticationService.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            await app.UseInfrastructure();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
