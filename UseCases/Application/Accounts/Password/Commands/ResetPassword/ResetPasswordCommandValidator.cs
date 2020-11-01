using Application.Common.Configuration;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Application.Accounts.Password.Commands.ResetPassword
{
    internal class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator(
            ApplicationConfiguration configuration)
        {
            RuleFor(v => v.AccountId)
                .NotEmpty();

            RuleFor(v => v.NewPassword)
                .MinimumLength(configuration.MinPasswordLength)
                .MaximumLength(configuration.MaxPasswordLength);

            RuleFor(v => v.ResetToken)
                .NotEmpty();
        }
    }
}
