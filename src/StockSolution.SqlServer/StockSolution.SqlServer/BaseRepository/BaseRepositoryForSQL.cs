using Microsoft.EntityFrameworkCore;
using SharpCompress.Common;
using StockSolution.SharedLibrary.Interfaces;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.BaseRepository
{
    public class BaseRepositoryForSQL<T> : IGenericInterface<T> where T : class
    {
        DbContext _context;
        DbSet<T> _dbset;
        public BaseRepositoryForSQL(DbContext dbcontext)
        {
            _context = dbcontext;
            _dbset = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _dbset.AddAsync(entity);

            }
            catch (Exception ex)
            {
                Logs.LogException.LogExceptions(ex);
                throw;
            }
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var entity = await FindByIdAsync(Id);
                _dbset.Remove(entity);

            }
            catch (Exception ex)
            {
                Logs.LogException.LogExceptions(ex);

                throw;

            }
            return true;
        }

        public async Task<T> FindByIdAsync(Guid Id)
        {
            return await _dbset.FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {


            try
            {
                _dbset.Update(entity);

            }
            catch (Exception ex)
            {
                Logs.LogException.LogExceptions(ex);
                throw;
            }
            return true;

        }
    }
}
