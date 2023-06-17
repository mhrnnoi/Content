using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.Common.Interfaces.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(Guid Id);
        Task<List<T>> GetByAll();
        Task<T> Update(T entity);
        Task<T> Remove(T entity);
    }
}