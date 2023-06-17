using System;
using BookStore.Application.Features.Books.Common;
using BookStore.Domain.Book.Entities;
using MediatR;

namespace BookStore.Application.Features.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(Guid Id) :  IRequest<BookDTO>;
    
}
