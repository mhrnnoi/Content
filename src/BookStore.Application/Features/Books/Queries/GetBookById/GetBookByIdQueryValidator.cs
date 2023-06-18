using System;
using BookStore.Application.Features.Books.Queries.GetBookById;
using FluentValidation;

namespace BookStore.Application.Features.Books.Queries.GetBookById

{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator( )
        {
            RuleFor(x => x.Id).NotNull().WithMessage("plz enter id");
            RuleFor(x => x.Id).NotEmpty().WithMessage("plz enter id");
            RuleFor(x => x.Id.ToString().Length).GreaterThanOrEqualTo(30).WithMessage("plz enter valid id");
            
            
        }
    }
}
