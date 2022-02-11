using FluentValidation;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie
{
    public class DeleteMovieCommandValidator:AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
        }
    }
}
