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
    public class DirectorService : IDirectorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;

        public DirectorService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task Add(DirectorDto dto)
        {
            await _unitofWork.DirectorRepository.Add(_mapper.Map<Director>(dto));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(DirectorDto dto)
        {
            _unitofWork.DirectorRepository.Delete(_mapper.Map<Director>(dto));
            _unitofWork.SaveChangesAsync();
        }

        public async Task<IList<DirectorDto>> Get(Expression<Func<DirectorDto, bool>> filter)
        {
            var expression = _mapper.Map<Expression<Func<Director, bool>>>(filter);
            var directors = await _unitofWork.DirectorRepository.Get(expression);
            return _mapper.Map<List<DirectorDto>>(directors);
        }

        public async Task<IList<DirectorDto>> GetAll()
        {
            var directors = await _unitofWork.DirectorRepository.GetAll();
            return _mapper.Map<List<DirectorDto>>(directors);
        }

        public async Task<IList<DirectorDto>> GetAllActive()
        {
            var directors = await _unitofWork.DirectorRepository.GetAllActive();
            return _mapper.Map<List<DirectorDto>>(directors);
        }

        public async Task<DirectorDto> GetbyId(int Id)
        {
            var director = await _unitofWork.DirectorRepository.GetbyId(Id);
            return _mapper.Map<DirectorDto>(director);
        }

        public void Update(DirectorDto dto)
        {
            _unitofWork.DirectorRepository.Update(_mapper.Map<Director>(dto));
            _unitofWork.SaveChangesAsync();
        }
    }
}
