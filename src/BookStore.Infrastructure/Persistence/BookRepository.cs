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
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Book entity)
        {
            await _context.Set<Book>().AddAsync(entity);
        }

        public async Task<List<Book>> GetByAllAsync()
        {
            return await _context.Set<Book>().ToListAsync();

        }

        public async Task<Book> GetByIdAsync(Guid id)
        {

            var book = await _context.Set<Book>().SingleOrDefaultAsync(x => x.Id == id) ?? null;
            if (book != null)
            {
                return book;
            }
            await _unitOfWork.DisposeAsync();
            throw new NullReferenceException("there is no book with this id");


        }

        public async Task RemoveAsync(Guid id)
        {
            var book = await GetByIdAsync(id);

            _context.Set<Book>().Remove(book);




        }

        public async Task UpdateAsync(Book entity)
        {
            var oldBook = await GetByIdAsync(entity.Id);
            _context.Entry(oldBook).State = EntityState.Detached;
            await RemoveAsync(oldBook.Id);
            _context.Entry(oldBook).State = EntityState.Detached;
            var newBook = _mapper.Map<Book>(entity);
            await AddAsync(newBook);


        }
    }
}