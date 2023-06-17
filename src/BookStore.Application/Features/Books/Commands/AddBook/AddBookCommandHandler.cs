using System;
using BookStore.Application.Common.Interfaces.Persistence;
using BookStore.Domain.Book.Entities;
using MediatR;

namespace BookStore.Application.Features.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookComand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookComandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<Book> Handle(AddBookComand request, CancellationToken cancellationToken)
        {
            _bookRepository.Add(request.Request)
        }
    }
}
