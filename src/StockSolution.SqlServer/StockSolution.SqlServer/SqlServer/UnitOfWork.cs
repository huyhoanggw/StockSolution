using Microsoft.EntityFrameworkCore;
using StockSolution.SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.SqlServer
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _dbcontext;

        public UnitOfWork(TContext dbcontext)
        {

            _dbcontext = dbcontext;
        }
        public async Task BeginTransaction(CancellationToken cancellationToken = default)
        {
            await _dbcontext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransaction(CancellationToken cancellationToken = default)
        {
            await _dbcontext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransaction(CancellationToken cancellationToken = default)
        {
            await _dbcontext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public async Task<int> SavechangeAsync(CancellationToken cancellationToken = default)
        {
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
