

using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class DirectorRepository:BaseRepository<Director>,IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {

        }
    }
}
