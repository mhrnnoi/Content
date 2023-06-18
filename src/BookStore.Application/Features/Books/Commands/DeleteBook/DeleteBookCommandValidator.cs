using System;
using BookStore.Application.Common.Interfaces.Persistence;
using FluentValidation;

namespace BookStore.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("plz enter id");
            RuleFor(x => x.Id).NotEmpty().WithMessage("plz enter id");
            RuleFor(x => x.Id.ToString().Length).GreaterThanOrEqualTo(30).WithMessage("plz enter valid id");
            
        }
        
    }
}
