using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {

        private readonly DiabetesDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public ReadRepository(DiabetesDbContext context)
        {
            _context = context;
        }



        public async Task<int> FilteredCountAsync(System.Linq.Expressions.Expression<Func<T, bool>> kosul)
        {
            return await Table.Where(kosul).CountAsync();
        }

        public async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByFiltered(System.Linq.Expressions.Expression<Func<T, bool>> kosul)
        {
            return await Table.Where(kosul).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetByFilteredList(System.Linq.Expressions.Expression<Func<T, bool>> kosul)
        {
            return await Table.Where(kosul).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
         ;  return await Table.FindAsync(id);
        }

        public Task<List<T>> GetByFilteredList(Expression<Func<T, bool>> kosul, params Expression<Func<T, object>>[] includes)
        {
           IQueryable<T> query = Table.Where(kosul);           
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            
            return query.ToListAsync();
        }

        public Task<T> GetByFiltered(Expression<Func<T, bool>> kosul, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table.Where(kosul);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefaultAsync();
        }
    }
}
