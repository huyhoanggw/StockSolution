using MediatR;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Queries.StockPrice.GetLatestStockPriceBySymbol
{
    public class GetLatestStockPriceBySymbolQuery : IRequest<ReponseResult<Domain.Entities.StockPrice>>
    {
        public string Symbol { get; set; }
    }
}
