

using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IActorService
    {
        Task Add(ActorDto dto);
        void Delete(ActorDto dto);
        void Update(ActorDto dto);
        Task<IList<ActorDto>> GetAll();
        Task<IList<ActorDto>> GetAllActive();
        Task<ActorDto> GetbyId(int Id);
        Task<IList<ActorDto>> Get(Expression<Func<ActorDto, bool>> filter);
    }
}
