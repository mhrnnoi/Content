using System;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Application.Features.Books.Common;
using BookStore.Domain.Book.Entities;
using MapsterMapper;
using MediatR;

namespace BookStore.Application.Features.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDTO>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public async Task<BookDTO> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _bookRepository.Add(book);
            return _mapper.Map<BookDTO>(request);
        }
    }
}
