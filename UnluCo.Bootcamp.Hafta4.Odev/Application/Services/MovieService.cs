using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;

        public MovieService(IMapper mapper,IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task Add(MovieDto dto)
        {
            await _unitofWork.MovieRepository.Add(_mapper.Map<Movie>(dto));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(MovieDto dto)
        {
            _unitofWork.MovieRepository.Delete(_mapper.Map<Movie>(dto));
            _unitofWork.SaveChangesAsync();
        }

        public async Task<IList<MovieDto>> Get(Expression<Func<MovieDto, bool>> filter)
        {
            var expression = _mapper.Map<Expression<Func<Movie, bool>>>(filter);
            var movies = await _unitofWork.MovieRepository.Get(expression);
            return _mapper.Map<List<MovieDto>>(movies);
        }

        public async Task<IList<MovieDto>> GetAll()
        {
            var movies = await _unitofWork.MovieRepository.GetAll();
            return _mapper.Map<List<MovieDto>>(movies);
        }

        public async Task<IList<MovieDto>> GetAllActive()
        {
            var movies= await _unitofWork.MovieRepository.GetAllActive();
            return _mapper.Map<List<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetbyId(int Id)
        {
            var movie = await _unitofWork.MovieRepository.GetbyId(Id);
            return _mapper.Map<MovieDto>(movie);
        }

        public void Update(MovieDto dto)
        {
            _unitofWork.MovieRepository.Update(_mapper.Map<Movie>(dto));
            _unitofWork.SaveChangesAsync();
        }
    }
}
