using System;
using FluentValidation;

namespace BookStore.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("title Is empty");
            RuleFor(x=>x.AuthorName).NotEmpty().WithMessage("AuthorName Is empty");
            RuleFor(x=>x.PublishedDate).NotEmpty().WithMessage("PublishedDate Is empty");
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id Is empty");

            RuleFor(x=>x.Title).MaximumLength(20).WithMessage("title maximum length is 20");
            RuleFor(x=>x.AuthorName).MaximumLength(20).WithMessage("AuthorName maximum length is 20");

            RuleFor(x => x.Id).NotNull().WithMessage("plz enter id");
            RuleFor(x => x.Id).NotEmpty().WithMessage("plz enter id");
            RuleFor(x => x.Id.ToString().Length).GreaterThanOrEqualTo(30).WithMessage("plz enter valid id");

        
        }
        
    }
}
