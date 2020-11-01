using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Accounts.Password.Commands.ResetPassword
{
    internal class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();

            RuleFor(v => v.NewPassword)
                .MinimumLength(8)
                .MaximumLength(256);

            RuleFor(v => v.ResetToken)
                .NotEmpty();
        }
    }
}
