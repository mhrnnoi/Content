using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Domain.Book.Entities;
using BookStore.Infrastructure.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Book entity)
        {
            await _context.Set<Book>().AddAsync(entity);
        }

        public async Task<List<Book>> GetByAll()
        {
           return  await _context.Set<Book>().ToListAsync();

        }

        public async Task<Book> GetById(Guid Id)
        {
            return await _context.Set<Book>().SingleAsync(x => x.Id == Id) ;


        }

        public void Remove(Book entity)
        {
            _context.Set<Book>().Remove(entity);

        }

        public async Task Update(Book entity)
        {
            var oldBook = await GetById(entity.Id);
            Remove(oldBook);
            await Add(entity);

        }
    }
}