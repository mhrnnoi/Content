using System;
using BookStore.Application.Features.Books.Queries.GetBookById;
using FluentValidation;

namespace BookStore.Application.Features.Books.Queries.GetBookById

{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator( )
        {
            RuleFor(x => x.Id).NotEmpty();
            
            
        }
    }
}
