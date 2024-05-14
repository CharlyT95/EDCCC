using FluentValidation;
using MediatR;
using ValidationException = EDCCC.Application.Exceptions.ValidationException;
namespace EDCCC.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

               var errorsF =  validationResults.SelectMany(s => s.Errors).Where(e => e != null).ToList();

                if (errorsF.Count() != 0)
                {
                    throw new ValidationException(errorsF);
                }
            }

            return await next();
        }
    }
}
