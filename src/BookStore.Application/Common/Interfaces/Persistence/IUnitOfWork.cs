using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        Task DisposeAsync();
    }
}