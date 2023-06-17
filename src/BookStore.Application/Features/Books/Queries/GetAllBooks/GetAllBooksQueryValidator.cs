using System;
using FluentValidation;

namespace BookStore.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryValidator : AbstractValidator<GetAllBooksQuery>
    {
        public GetAllBooksQueryValidator()
        {

        }
    }
}
