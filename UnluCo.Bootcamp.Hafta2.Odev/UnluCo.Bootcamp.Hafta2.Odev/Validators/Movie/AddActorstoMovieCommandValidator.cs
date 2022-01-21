using FluentValidation;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie
{
    public class AddActorstoMovieCommandValidator : AbstractValidator<AddActorstoMovieCommand>
    {
        public AddActorstoMovieCommandValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
            RuleFor(x => x.Model.ActorIds.Length).GreaterThan(0);
        }
    }
}
