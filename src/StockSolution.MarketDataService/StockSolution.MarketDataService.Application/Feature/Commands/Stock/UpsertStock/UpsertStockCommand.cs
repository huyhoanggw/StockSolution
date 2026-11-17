using MediatR;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Commands.Stock.UpsertStock
{
    public class UpsertStockCommand : IRequest<ReponseResult<bool>>
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; } = null!;

    }
}
