using System;
using FluentValidation;

namespace BookStore.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
        }
        
    }
}
