using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Features.Books.Common;
using MediatR;

namespace BookStore.Application.Features.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(string Title, string AuthorName, DateTime PublishedDate) : IRequest<BookDTO>;
    
}