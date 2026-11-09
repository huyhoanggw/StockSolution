using Microsoft.VisualBasic;
using StockSolution.SharedLibrary.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.Interfaces
{
    public interface IGenericInterface<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(Guid Id);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
    }
}
