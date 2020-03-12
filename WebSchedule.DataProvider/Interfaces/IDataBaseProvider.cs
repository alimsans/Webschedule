using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchedule.Infrastructure.Interfaces
{
    internal interface IDataBaseProvider : IDisposable
    {
        IQueryable<T> Set<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
        void Remove<T>(T entity) where T : class;
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;
        Task SaveAsync();
    }
}
