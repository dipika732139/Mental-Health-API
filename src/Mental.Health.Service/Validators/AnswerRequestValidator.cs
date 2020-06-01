using FluentValidation;
using Mental.Health.Model.Models.Error;

namespace Mental.Health.Service
{
    public class AnswerRequestValidator : AbstractValidator<AnswerRequest>
    {
        public AnswerRequestValidator()
        {
            RuleFor(x => x.UserId)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("UserId"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("UserId"));

            RuleFor(x => x.MentalHealthTestId)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("MentalHealthTestId"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("MentalHealthTestId"));

            RuleFor(x => x.QuestionNumber)
                .Must(IsValidQuestionOrOptionNumber)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("QuestionNumber"));

            RuleFor(x => x.OptionNumber)
                .Must(IsValidQuestionOrOptionNumber)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("OptionNumber"));
        }

        private bool IsValidQuestionOrOptionNumber(int number)
        {
            if (number <= 0)
                return false;
            return true;
        }
    }
}
