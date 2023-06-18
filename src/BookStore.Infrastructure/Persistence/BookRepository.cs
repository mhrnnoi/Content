using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Domain.Book.Entities;
using BookStore.Infrastructure.Persistence.DataContext;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(Book entity)
        {
            await _context.Set<Book>().AddAsync(entity);
        }

        public async Task<List<Book>> GetByAll()
        {
            return await _context.Set<Book>().ToListAsync();

        }

        public async Task<Book> GetById(Guid Id)
        {

            var book = await _context.Set<Book>().SingleOrDefaultAsync(x => x.Id == Id) ?? null;
            if (book != null)
            {
                return book;
            }
            throw new NullReferenceException("there is no book with this id");


        }

        public async Task Remove(Guid id)
        {
            var book = await _context.Set<Book>().SingleOrDefaultAsync(x => x.Id == id) ?? null;
            if (book == null)
            {
            throw new NullReferenceException("there is no book with this id");
                
            }
            _context.Set<Book>().Remove(book);




        }

        public async Task Update(Book entity)
        {
            var oldBook = await _context.Set<Book>().SingleOrDefaultAsync(x => x.Id == entity.Id) ?? null;
            if (oldBook != null)
            {
                _context.Set<Book>().Remove(oldBook);
            }
            var newBook = _mapper.Map<Book>(entity);
            await _context.Set<Book>().AddAsync(newBook);

        }
    }
}