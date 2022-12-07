using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = SpaceFork.eShop.Ordering.Application.Exceptions.ValidationException;

namespace SpaceFork.eShop.Ordering.Application.Behaviours
{
    public class ValidatinoBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidatinoBehaviour(IEnumerable<IValidator> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            if (_validators.Any())
            {
                var validationResult = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));
                
                var validationfailurs = validationResult.SelectMany(validator => validator.Errors).ToList(); 
                
                if(validationfailurs != null && validationfailurs.Any())
                {
                    throw new ValidationException(validationfailurs);
                }
            }
            return await next();
        }
    }
}
