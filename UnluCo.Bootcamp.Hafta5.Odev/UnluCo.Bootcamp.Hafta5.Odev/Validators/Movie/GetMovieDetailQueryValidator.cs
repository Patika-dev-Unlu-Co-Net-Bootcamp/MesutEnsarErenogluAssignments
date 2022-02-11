using FluentValidation;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries.GetMovieDetail;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Validators.Movie
{
    public class GetMovieDetailQueryValidator:AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}
