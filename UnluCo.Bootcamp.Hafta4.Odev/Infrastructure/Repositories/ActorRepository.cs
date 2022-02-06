using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System;

namespace Infrastructure.Repositories
{
    public class ActorRepository: BaseRepository<Actor>,IActorRepository
    {
        public ActorRepository(AppDbContext context):base(context)
        {

        }
    }
}
