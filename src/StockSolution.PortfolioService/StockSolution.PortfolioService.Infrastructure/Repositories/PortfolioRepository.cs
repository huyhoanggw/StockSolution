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
    public class PortfolioRepository : BaseRepositoryForSQL<Portfolio>, IPortfolioRepository
    {
        private readonly DbContext _dbcontext;

        public PortfolioRepository(DbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Portfolio>> GetPortfoliosByUserId(Guid UserId)
        {
            return await _dbcontext.Set<Portfolio>().Where(x => x.UserId.Equals(UserId)).ToListAsync();
        }
    }
}
