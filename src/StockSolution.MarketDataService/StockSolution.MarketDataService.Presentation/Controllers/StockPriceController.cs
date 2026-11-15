using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockSolution.MarketDataService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockPriceController(IMediator mediator) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UpsertStockPrice([FromBody] Domain.Entities.StockPrice stockPrice)
        {
            var result = await mediator.Send(new Application.Feature.Commands.StockPrice.UpsertStockPrice.UpsertStockPriceCommand()
            {
                Symbol = stockPrice.Symbol,
                LastPrice = stockPrice.LastPrice,
                Change = stockPrice.Change,
                ChangePercent = stockPrice.ChangePercent,
                OpenPrice = stockPrice.OpenPrice,
                HighestPrice = stockPrice.HighestPrice,
                LowestPrice = stockPrice.LowestPrice,
                TotalVolume = stockPrice.TotalVolume,
                Timestamp = stockPrice.Timestamp
            });
            return result.Flag is true ? Ok(result) : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetStockPriceBySymbol([FromQuery] string symbol)
        {
            var result = await mediator.Send(new Application.Feature.Queries.StockPrice.GetLatestStockPriceBySymbol.GetLatestStockPriceBySymbolQuery() { Symbol = symbol });
            return result.Object is not null ? Ok(result) : NotFound();
        }
    }
}
