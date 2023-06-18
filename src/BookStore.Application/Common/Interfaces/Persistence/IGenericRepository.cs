using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.Common.Interfaces.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(Guid Id);
        Task<List<T>> GetByAllAsync();
        Task UpdateAsync(T entity);
        Task RemoveAsync(Guid Id);
    }
}