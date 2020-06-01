using System;
using FluentValidation;
using Mental.Health.Model.Models.Error;

namespace Mental.Health.Service
{
    public class QuestionRequestValidator : AbstractValidator<QuestionRequest>
    {
        public QuestionRequestValidator()
        {
            RuleFor(x => x.MentalHealthTestId)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("MentalHealthTestId"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("MentalHealthTestId"));
            RuleFor(x => x.QuestionNumber)
                .Must(IsValidQuestionNumber)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("QuestionNumber"));
        }

        private bool IsValidQuestionNumber(int questionNumber)
        {
            if (questionNumber <= 0)
                return false;
            return true;
        }
    }
}
