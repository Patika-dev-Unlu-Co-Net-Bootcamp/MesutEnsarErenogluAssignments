

using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.UnitofWork
{
    public interface IUnitofWork
    {
        public IActorRepository ActorRepository  { get; }
        public IMovieRepository MovieRepository { get; }
        public IDirectorRepository DirectorRepository { get; }
        public IGenreRepository GenreRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
