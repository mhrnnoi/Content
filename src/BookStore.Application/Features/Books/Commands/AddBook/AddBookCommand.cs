using System;
using BookStore.Application.Features.Books.Common;
using BookStore.Domain.Book.Entities;
using MediatR;

namespace BookStore.Application.Features.Books.Commands.AddBook
{
    public record AddBookCommand(string Title, string AuthorName, DateTime PublishedDate) :  IRequest<BookDTO>;
    
}
