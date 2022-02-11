using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public GetMovieDetailQuery(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public GetMovieDetailQueryVM Handle()
        {
            var movie = _db.Movies.Include(x=>x.Director).Include(x=>x.Genre).Where(x => x.Id == MovieId && x.IsActive == true).FirstOrDefault();
            if (movie == null)
            {
                throw new InvalidOperationException("Aradığınız film bulunamadı");
            }
            GetMovieDetailQueryVM vm = _mapper.Map<GetMovieDetailQueryVM>(movie);
            vm.ActorNames = _db.MovieAndActors.Where(x => x.MovieId == movie.Id).Select(x => x.Actor.FullName).ToArray();
            return vm;
        }
    }
}
