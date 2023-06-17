using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.User.Entities;

namespace BookStore.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        
    }
}