using MediatR;
using StockSolution.MarketDataService.Application.Feature.Commands.Stock.UpsertStock;
using StockSolution.MarketDataService.Application.IRepository;
using StockSolution.SharedLibrary.Logs;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Commands.StockPrice.UpsertStockPrice
{
    public class UpserStockPriceCommandHandler(IStockPriceRepository stockPriceRepository) : IRequestHandler<UpsertStockPriceCommand, ReponseResult<bool>>
    {
        public async Task<ReponseResult<bool>> Handle(UpsertStockPriceCommand request, CancellationToken cancellationToken)
        {

            LogException.LogToFile("UpserStockPriceCommandHandler Begin:");
            await stockPriceRepository.UpsertAsync(new Domain.Entities.StockPrice
            {
                Symbol = request.Symbol,
                LastPrice = request.LastPrice,
                Change = request.Change,
                ChangePercent = request.ChangePercent,
                OpenPrice = request.OpenPrice,
                HighestPrice = request.HighestPrice,
                LowestPrice = request.LowestPrice,
                TotalVolume = request.TotalVolume,
                Timestamp = request.Timestamp
            });
            LogException.LogToFile("UpserStockPriceCommandHandler End:");

            return new ReponseSuccess<bool>(true, "upsert stock price successfully");
        }
    }
}
