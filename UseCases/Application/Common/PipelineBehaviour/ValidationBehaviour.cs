using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.PipelineBehaviour
{
    internal class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehaviour(
            IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.Errors.Count != 0)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await next();
        }
    }
}
