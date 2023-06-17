using System;
using BookStore.Application.Features.Books.Common;
using MediatR;

namespace BookStore.Application.Features.Books.Queries.GetAllBooks
{
    public record GetAllBooksQuery() : IRequest<List<BookDTO>>;
   
}
