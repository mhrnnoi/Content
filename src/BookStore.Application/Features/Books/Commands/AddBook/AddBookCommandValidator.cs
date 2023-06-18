using System;
using FluentValidation;

namespace BookStore.Application.Features.Books.Commands.AddBook
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("title Is empty");
            RuleFor(x => x.Title).MinimumLength(1).WithMessage("title Is empty");
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("AuthorName Is empty");
            RuleFor(x => x.PublishedDate).NotEmpty().WithMessage("PublishedDate Is empty");

            RuleFor(x => x.Title).MaximumLength(20).WithMessage("title maximum length is 20");
            RuleFor(x => x.AuthorName).MaximumLength(20).WithMessage("AuthorName maximum length is 20");


        }
    }
}
