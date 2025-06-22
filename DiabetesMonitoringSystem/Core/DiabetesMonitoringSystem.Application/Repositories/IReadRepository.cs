using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.Repositories
{
    public interface IReadRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByFiltered(Expression<Func<T, bool>> kosul);
        Task<T> GetByFiltered(Expression<Func<T, bool>> kosul, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetByFilteredList(Expression<Func<T, bool>> kosul);
        Task<List<T>> GetByFilteredList(Expression<Func<T, bool>> kosul, params Expression<Func<T, object>>[] includes);
        Task<int> FilteredCountAsync(Expression<Func<T, bool>> kosul);
        Task<int> CountAsync();

    }
   
}
