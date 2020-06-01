using FluentValidation;
using static Mental.Health.Errors;

namespace Mental.Health.Service
{
    public static class Validations
    {
        public static void EnsureValid<TRequest>(TRequest request, IValidator<TRequest> validator)
        {
            var validationError = ClientSide.ValidationFailure();

            if (request == null)
                throw validationError;

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                foreach (var validationFailure in validationResult.Errors)
                {
                    validationError.Infos.Add(new ErrorInfo(validationFailure.ErrorCode, validationFailure.ErrorMessage));
                }
                throw validationError;
            }
        }
    }
}
