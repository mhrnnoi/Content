using System;
using BookStore.Domain.Book.Entities;
using MediatR;

namespace BookStore.Application.Features.Books.Commands.AddBook
{
    public record AddBookCommand() :  IRequest<Book>;
    
}
