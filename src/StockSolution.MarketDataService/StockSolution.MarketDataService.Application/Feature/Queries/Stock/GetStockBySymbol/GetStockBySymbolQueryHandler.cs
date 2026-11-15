using MediatR;
using StockSolution.MarketDataService.Application.IRepository;
using StockSolution.SharedLibrary.Logs;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Queries.Stock.GetStockBySymbol
{
    public class GetStockBySymbolQueryHandler(IStockRepository stockRepository) : IRequestHandler<GetStockBySymbolQuery, ReponseResult<StockSolution.MarketDataService.Domain.Entities.Stock>>a
    {
        public async Task<ReponseResult<Domain.Entities.Stock>> Handle(GetStockBySymbolQuery request, CancellationToken cancellationToken)
        {
            LogException.LogToFile("GetStockBySymbolQueryHandler Begin:");
            var result = await stockRepository.GetStockBySymbolAsync(request.Symbol);
            if (result is null) return new ReponseError<Domain.Entities.Stock>("Stock not found");

            LogException.LogToFile("GetStockBySymbolQueryHandler End:");
            return new ReponseSuccess<Domain.Entities.Stock>(result);
        }
    }
}
