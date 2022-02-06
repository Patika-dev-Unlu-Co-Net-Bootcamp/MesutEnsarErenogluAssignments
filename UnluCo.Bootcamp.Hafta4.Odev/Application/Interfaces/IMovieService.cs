using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        Task Add(MovieDto dto);
        void Delete(MovieDto dto);
        void Update(MovieDto dto);
        Task<IList<MovieDto>> GetAll();
        Task<IList<MovieDto>> GetAllActive();
        Task<MovieDto> GetbyId(int Id);
        Task<IList<MovieDto>> Get(Expression<Func<MovieDto, bool>> filter);
    }
}
