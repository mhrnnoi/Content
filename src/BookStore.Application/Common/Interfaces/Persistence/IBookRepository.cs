using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Book.Entities;

namespace BookStore.Application.Common.Interfaces.Persistence
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        
    }
}