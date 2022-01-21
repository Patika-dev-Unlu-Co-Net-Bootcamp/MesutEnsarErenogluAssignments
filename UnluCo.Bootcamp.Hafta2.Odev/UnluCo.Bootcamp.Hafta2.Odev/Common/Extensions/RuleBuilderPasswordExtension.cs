using FluentValidation;

namespace UnluCo.Bootcamp.Hafta2.Odev.Common.Extensions
{
    public static class RuleBuilderPasswordExtension
    {
        //Bu extension ile modelden alınan password customize edilerek kontrol edilebilecektir.
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 5)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("Şifre boş olmaz!")
                .MinimumLength(minimumLength).WithMessage("Şifre 5 karakterden uzun olmalı!")
                .Matches("[A-Z]").WithMessage("En az bir büyük harf içermelidir!")
                .Matches("[a-z]").WithMessage("En az bir küçük harf içermelidir!")
                .Matches("[0-9]").WithMessage("En az bir sayı içermelidir");
            return options;
        }
    }
}
