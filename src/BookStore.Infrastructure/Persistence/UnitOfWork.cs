using System;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Infrastructure.Persistence.DataContext;

namespace BookStore.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
