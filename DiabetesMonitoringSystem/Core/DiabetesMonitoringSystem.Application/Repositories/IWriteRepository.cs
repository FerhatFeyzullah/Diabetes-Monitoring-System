using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesMonitoringSystem.Application.Repositories
{
    public interface IWriteRepository<T> where T : class
    {

        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task RemoveAsync(int id);

    }
}
