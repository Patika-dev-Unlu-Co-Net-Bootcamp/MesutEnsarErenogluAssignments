

using Domain.Interfaces;
using Infrastructure.Context;
using System.Threading.Tasks;

namespace Infrastructure.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;

        public IActorRepository ActorRepository  { get; }

        public IMovieRepository MovieRepository { get; }

        public IDirectorRepository DirectorRepository { get; }

        public IGenreRepository GenreRepository { get; }

        public UnitofWork(AppDbContext context, IActorRepository ActorRepo, IMovieRepository MovieRepo,IDirectorRepository DirectorRepo,IGenreRepository GenreRepo)
        {
            _context = context;
            ActorRepository = ActorRepo;
            MovieRepository = MovieRepo;
            DirectorRepository = DirectorRepo;
            GenreRepository = GenreRepo;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
