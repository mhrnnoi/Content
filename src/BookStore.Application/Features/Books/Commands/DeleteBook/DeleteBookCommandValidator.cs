using System;
using FluentValidation;

namespace BookStore.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty();
        }
        
    }
}
