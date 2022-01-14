using FluentValidation;
using System;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.MovieName).NotEmpty().Length(1, 100);
            RuleFor(command => command.Model.ReleaseDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.DirectorId).GreaterThan(0);
        }
    }
}
