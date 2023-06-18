using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Contracts.Book.Request
{
    public record UpdateBookRequest(Guid Id, string Title, string AuthorName, DateTime PublishedDate);
   
}