using System;
using FluentValidation;

namespace BookStore.Application.Features.Books.Commands.AddBook
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator( )
        {
            RuleFor(x => x.Title).NotEmpty();
            
        }
    }
}
