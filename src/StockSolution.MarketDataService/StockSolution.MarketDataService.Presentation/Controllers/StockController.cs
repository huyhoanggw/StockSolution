using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockSolution.SharedLibrary.Reponse;

namespace StockSolution.MarketDataService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StockController(IMediator mediator) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UpsertStock([FromBody] Domain.Entities.Stock stock)
        {
            var result = await mediator.Send(new Application.Feature.Commands.Stock.UpsertStock.UpsertStockCommand()
            { Name = stock.Name, Exchange = stock.Exchange, Symbol = stock.Symbol });
            return result.Flag is true ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetStockBySymbol([FromQuery] string symbol)
        {
            var result = await mediator.Send(new Application.Feature.Queries.Stock.GetStockBySymbol.GetStockBySymbolQuery() { Symbol = symbol });
            return result.Object is not null ? Ok(result) : NotFound();
        }
    }
}
