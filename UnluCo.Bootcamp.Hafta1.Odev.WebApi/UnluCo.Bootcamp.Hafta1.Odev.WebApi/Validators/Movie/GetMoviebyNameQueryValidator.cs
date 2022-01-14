using FluentValidation;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie
{
    public class GetMoviebyNameQueryValidator: AbstractValidator<GetMoviebyNameQuery>
    {
        public GetMoviebyNameQueryValidator()
        {
            RuleFor(x => x.MovieName).NotEmpty().Length(1, 100);
        }
    }
}
