using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> SavechangeAsync(CancellationToken cancellationToken = default);
        public Task BeginTransaction(CancellationToken cancellationToken = default);
        public Task CommitTransaction(CancellationToken cancellationToken = default);
        public Task RollbackTransaction(CancellationToken cancellationToken = default);
    }
}
