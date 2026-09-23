
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Muhasebe.Application.Messaging;

namespace Muhasebe.Application.Behaviour
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .GroupBy(
                f => f.PropertyName,
                f=> f.ErrorMessage, (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                }).ToDictionary(f => f.Key, f => f.Values[0]);


            if (failures.Count != 0)
            {
                var errors = failures.Select(f => new ValidationFailure
                {
                    ErrorCode = f.Key,
                    PropertyName = f.Value
                });
                throw new ValidationException(errors);
            }
            return await next();
        }
    }
}
