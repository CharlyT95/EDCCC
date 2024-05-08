using FluentValidation.Results;

namespace EDCCC.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("Hay uno o más errores en validacion")
        {
            Errors = new Dictionary<string, string[] >();  
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }


    }
}
