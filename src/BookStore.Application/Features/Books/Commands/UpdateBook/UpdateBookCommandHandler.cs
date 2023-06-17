using System;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Application.Features.Books.Common;
using BookStore.Domain.Book.Entities;
using MapsterMapper;
using MediatR;

namespace BookStore.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDTO>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            
        }
        public async Task<BookDTO> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book =  _mapper.Map<Book>(request);
            await _bookRepository.Update(book);
            return _mapper.Map<BookDTO>(request);

        }
    }
}
