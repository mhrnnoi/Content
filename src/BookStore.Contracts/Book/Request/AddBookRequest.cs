using System;

namespace BookStore.Contracts.Book.Request
{
    public record AddBookRequest(string Title, string AuthorName, DateTime PublishedDate);
   
}
