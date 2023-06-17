using System;

namespace BookStore.Application.Features.Books.Common
{
    public record BookDTO(string Title, string AuthorName, DateTime PublishedDate);

}
