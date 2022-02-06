

using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenreService
    {
        Task Add(GenreDto dto);
        void Delete(GenreDto dto);
        void Update(GenreDto dto);
        Task<IList<GenreDto>> GetAll();
        Task<IList<GenreDto>> GetAllActive();
        Task<GenreDto> GetbyId(int Id);
        Task<IList<GenreDto>> Get(Expression<Func<GenreDto, bool>> filter);
    }
}
