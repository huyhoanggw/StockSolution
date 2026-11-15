using MediatR;
using StockSolution.MarketDataService.Application.IRepository;
using StockSolution.SharedLibrary.Logs;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Queries.StockPrice.GetLatestStockPriceBySymbol
{
    public class GetLatestStockPriceBySymbolQueryHandler(IStockPriceRepository stockPriceRepository) : IRequestHandler<GetLatestStockPriceBySymbolQuery, ReponseResult<Domain.Entities.StockPrice>>
    {
        public async Task<ReponseResult<Domain.Entities.StockPrice>> Handle(GetLatestStockPriceBySymbolQuery request, CancellationToken cancellationToken)
        {
            LogException.LogToFile("GetLatestStockPriceBySymbolQueryHandler Begin:");
            var result = await stockPriceRepository.GetLatestStockPriceBySymbolAsync(request.Symbol);
            if (result is null) return new ReponseError<Domain.Entities.StockPrice>("Stock price not found");
            LogException.LogToFile("GetLatestStockPriceBySymbolQueryHandler End:");
            return new ReponseSuccess<Domain.Entities.StockPrice>(result, "Get latest stock price by symbol successfully");
        }
    }
}
