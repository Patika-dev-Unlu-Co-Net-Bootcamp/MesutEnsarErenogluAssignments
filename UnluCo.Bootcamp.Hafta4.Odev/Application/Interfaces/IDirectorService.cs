
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDirectorService
    {
        Task Add(DirectorDto dto);
        void Delete(DirectorDto dto);
        void Update(DirectorDto dto);
        Task<IList<DirectorDto>> GetAll();
        Task<IList<DirectorDto>> GetAllActive();
        Task<DirectorDto> GetbyId(int Id);
        Task<IList<DirectorDto>> Get(Expression<Func<DirectorDto, bool>> filter);
    }
}
