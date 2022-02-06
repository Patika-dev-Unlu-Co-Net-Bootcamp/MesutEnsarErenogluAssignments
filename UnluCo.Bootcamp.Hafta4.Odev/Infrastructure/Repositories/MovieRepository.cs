

using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>,IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {

        }
    }
}
