using System;

namespace BookStore.Contracts.Book.Request
{
    public record GetBookByIdRequest(Guid id);

}
