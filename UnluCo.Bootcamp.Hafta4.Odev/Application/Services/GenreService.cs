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
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;

        public GenreService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task Add(GenreDto dto)
        {
            await _unitofWork.GenreRepository.Add(_mapper.Map<Genre>(dto));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(GenreDto dto)
        {
            _unitofWork.GenreRepository.Delete(_mapper.Map<Genre>(dto));
            _unitofWork.SaveChangesAsync();
        }

        public async Task<IList<GenreDto>> Get(Expression<Func<GenreDto, bool>> filter)
        {
            var expression = _mapper.Map<Expression<Func<Genre, bool>>>(filter);
            var genres = await _unitofWork.GenreRepository.Get(expression);
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public async Task<IList<GenreDto>> GetAll()
        {
            var genres = await _unitofWork.GenreRepository.GetAll();
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public async Task<IList<GenreDto>> GetAllActive()
        {
            var genres = await _unitofWork.GenreRepository.GetAllActive();
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public async Task<GenreDto> GetbyId(int Id)
        {
            var genre = await _unitofWork.GenreRepository.GetbyId(Id);
            return _mapper.Map<GenreDto>(genre);
        }

        public void Update(GenreDto dto)
        {
            _unitofWork.GenreRepository.Update(_mapper.Map<Genre>(dto));
            _unitofWork.SaveChangesAsync();
        }
    }
}
