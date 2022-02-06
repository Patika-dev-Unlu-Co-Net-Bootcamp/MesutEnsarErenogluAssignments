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
    public class ActorService : IActorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;

        public ActorService(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task Add(ActorDto dto)
        {
            await _unitofWork.ActorRepository.Add(_mapper.Map<Actor>(dto));
            await _unitofWork.SaveChangesAsync();
        }

        public void Delete(ActorDto dto)
        {
            _unitofWork.ActorRepository.Delete(_mapper.Map<Actor>(dto));
            _unitofWork.SaveChangesAsync();
        }

        public async Task<IList<ActorDto>> Get(Expression<Func<ActorDto, bool>> filter)
        {
            var expression = _mapper.Map<Expression<Func<Actor, bool>>>(filter);
            var actors = await _unitofWork.ActorRepository.Get(expression);
            return _mapper.Map<List<ActorDto>>(actors);
        }

        public async Task<IList<ActorDto>> GetAll()
        {
            var actors = await _unitofWork.ActorRepository.GetAll();
            return _mapper.Map<List<ActorDto>>(actors);
        }

        public async Task<IList<ActorDto>> GetAllActive()
        {
            var actors = await _unitofWork.ActorRepository.GetAllActive();
            return _mapper.Map<List<ActorDto>>(actors);
        }

        public async Task<ActorDto> GetbyId(int Id)
        {
            var actor = await _unitofWork.ActorRepository.GetbyId(Id);
            return _mapper.Map<ActorDto>(actor);
        }

        public void Update(ActorDto dto)
        {
            _unitofWork.ActorRepository.Update(_mapper.Map<Actor>(dto));
            _unitofWork.SaveChangesAsync();
        }
    }
}
