using MediatR;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Queries.Stock.GetStockBySymbol
{
    public class GetStockBySymbolQuery : IRequest<ReponseResult<StockSolution.MarketDataService.Domain.Entities.Stock>>
    {
        public string Symbol { get; set; }
    {
    }
}
