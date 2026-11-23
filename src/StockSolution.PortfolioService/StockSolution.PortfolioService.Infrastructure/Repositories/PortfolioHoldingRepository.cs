using Microsoft.EntityFrameworkCore;
using StockSolution.PortfolioService.Application.Interfaces;
using StockSolution.PortfolioService.Domain.Entities;
using StockSolution.SharedLibrary.BaseRepository;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Infrastructure.Repositories
{
    public class PortfolioHoldingRepository : BaseRepositoryForSQL<PortfolioHolding>, IPortfolioHoldingRepository
    {
        private readonly DbContext _dbcontext;

        public PortfolioHoldingRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;

        }

        public Task<decimal> CheckCurrentPrice(string Symbol)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetAveragePirce(Guid Id)
        {
            return await _dbcontext.Set<PortfolioHolding>().AsNoTracking().Where(x => x.Id == Id).Select(x => x.AverageCost).FirstOrDefaultAsync();
        }

        public async Task<decimal> GetFieldsQuanlityShares(Guid Id)
        {
            return await _dbcontext.Set<PortfolioHolding>().AsNoTracking().Where(x => x.Id.Equals(Id)).Select(x => x.Quantity).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PortfolioHolding>> GetPortfolioHoldingsByPortfolioId(Guid PortfolioId)
        {
            return await _dbcontext.Set<PortfolioHolding>().Where(x => x.PorfolioId == PortfolioId).ToListAsync();
        }
    }
}
