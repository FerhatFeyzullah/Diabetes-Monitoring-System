using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabetesMonitoringSystem.Application.Repositories;
using DiabetesMonitoringSystem.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DiabetesMonitoringSystem.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {

        private readonly DiabetesDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public WriteRepository(DiabetesDbContext context)
        {
            _context = context;
        }

        

        public async Task AddAsync(T t)
        {
           await Table.AddAsync(t);
           await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T t)
        {
            Table.Update(t);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            var value = Table.Find(id);
            Table.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
    
}
