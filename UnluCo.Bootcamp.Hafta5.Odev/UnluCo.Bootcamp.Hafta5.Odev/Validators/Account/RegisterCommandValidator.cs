using FluentValidation;
using UnluCo.Bootcamp.Hafta2.Odev.Application.AccountOperations.Commands;
using UnluCo.Bootcamp.Hafta2.Odev.Common.Extensions;

namespace UnluCo.Bootcamp.Hafta2.Odev.Validators.Account
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(command => command.Model.Email).NotEmpty().EmailAddress().WithMessage("Email girişi zorunludur");
            RuleFor(command => command.Model.Password).Password();
            RuleFor(command => command.Model.ConfirmedPassword).NotEmpty().Equal(x => x.Model.Password);
            RuleFor(command => command.Model.FirstName).NotEmpty();
            RuleFor(command => command.Model.LastName).NotEmpty();
        }
    }
}
