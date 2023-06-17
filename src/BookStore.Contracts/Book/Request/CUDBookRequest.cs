using System;

namespace BookStore.Contracts.Book.Request
{
    public record CUDBookRequest(string Title, string AuthorName, DateTime PublishedDate);
   
}
