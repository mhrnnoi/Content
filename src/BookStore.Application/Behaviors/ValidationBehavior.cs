using FluentValidation;
using MediatR;

namespace BookStore.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> 
    {
        private readonly IValidator<TRequest> _validator;
        public ValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (result.IsValid)
            {
                await next();
            }
            var errors = string.Join(" ,\n", result.Errors.Select(x => x.ErrorMessage));
            throw new Exception(errors);

        }

        
    }
}