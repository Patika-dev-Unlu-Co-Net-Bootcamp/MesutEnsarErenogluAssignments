using FluentValidation;
using UnluCo.Bootcamp.Hafta2.Odev.Application.AccountOperations.Commands;
using UnluCo.Bootcamp.Hafta2.Odev.Common.Extensions;

namespace UnluCo.Bootcamp.Hafta2.Odev.Validators.Account
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(command => command.Model.Email).NotEmpty().EmailAddress().WithMessage("Email adresi boş olmaz!");
            RuleFor(command => command.Model.Password).Password();
        }
    }
}
