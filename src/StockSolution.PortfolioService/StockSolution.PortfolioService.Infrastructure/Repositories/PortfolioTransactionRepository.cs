using Microsoft.EntityFrameworkCore;
using StockSolution.PortfolioService.Application.Interfaces;
using StockSolution.PortfolioService.Domain.Entities;
using StockSolution.SharedLibrary.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.PortfolioService.Infrastructure.Repositories
{
    public class PortfolioTransactionRepository : BaseRepositoryForSQL<PortfolioTransaction>, IPortfolioTransactionRepository
    {
        private readonly DbContext _dbcontext;

        public PortfolioTransactionRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<PortfolioTransaction>> GetPortfolioTransactionsByPortfolioId(Guid PortfolioId)
        {
            return await _dbcontext.Set<PortfolioTransaction>().Where(x => x.PortfolioId == PortfolioId).ToListAsync();
        }
    }
}
