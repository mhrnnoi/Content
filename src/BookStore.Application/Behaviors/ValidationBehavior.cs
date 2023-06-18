using BookStore.Application.Common.Interfaces.Persistence;
using FluentValidation;
using MediatR;

namespace BookStore.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> 
    {
        private readonly IValidator<TRequest> _validator;
                private readonly IUnitOfWork _unitOfWork;

        public ValidationBehavior(IValidator<TRequest> validator, IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (result.IsValid)
            {
                await next();
            }
            await _unitOfWork.DisposeAsync();
            var errors = string.Join(" ,\n", result.Errors.Select(x => x.ErrorMessage));
            throw new Exception(errors);

        }

        
    }
}