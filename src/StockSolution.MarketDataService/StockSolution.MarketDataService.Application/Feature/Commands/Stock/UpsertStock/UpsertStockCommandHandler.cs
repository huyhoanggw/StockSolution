using MediatR;
using StockSolution.MarketDataService.Application.IRepository;
using StockSolution.SharedLibrary.Logs;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.MarketDataService.Application.Feature.Commands.Stock.UpsertStock
{
    public class UpsertStockCommandHandler(IStockRepository stockRepository) : IRequestHandler<UpsertStockCommand, ReponseResult<bool>>
    {
        public async Task<ReponseResult<bool>> Handle(UpsertStockCommand request, CancellationToken cancellationToken)
        {
            LogException.LogToFile("UpsertStockCommandHandler Begin:");
            await stockRepository.UpsertAsync(new Domain.Entities.Stock()
            {
                Symbol = request.Symbol,
                Name = request.Name,
                Exchange = request.Exchange
            });
            LogException.LogToFile("UpsertStockCommandHandler End:");
            return new ReponseSuccess<bool>(true, "Stock upserted successfully");
        }
    }
}
