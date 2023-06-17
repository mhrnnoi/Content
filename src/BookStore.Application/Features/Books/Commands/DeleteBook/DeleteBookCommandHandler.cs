using System;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Application.Features.Books.Common;
using BookStore.Domain.Book.Entities;
using MapsterMapper;
using MediatR;

namespace BookStore.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BookDTO>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookDTO> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            var bookDto = _mapper.Map<BookDTO>(request);
            await _bookRepository.Remove(book);
            return bookDto;

        }
    }
}
