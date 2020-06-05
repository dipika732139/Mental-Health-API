using FluentValidation;
using Mental.Health.Model.Models.Error;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health.Service.Validators
{
    class CommunityConnectRequestValidator : AbstractValidator<CommunityConnectRequest>
    {
        public CommunityConnectRequestValidator()
        {
            RuleFor(x => x.UserId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(FaultCodes.MissingField)
            .WithMessage(ErrorMessages.MissingField("UserId"))
            .NotEmpty()
            .WithErrorCode(FaultCodes.InvalidField)
            .WithMessage(ErrorMessages.InvalidField("UserId"));
        }
    }
}
