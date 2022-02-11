using FluentValidation;
using System;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie
{
    public class UpdateMovieCommandValidator:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.DirectorId).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.MovieName).NotEmpty().Length(1, 100);
            RuleFor(command => command.Model.ReleaseDate).LessThan(DateTime.Now);

        }
    }
}
