using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.QueryVMs;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries
{
    public class GetMoviebyNameQuery
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public string MovieName { get; set; }
        public GetMoviebyNameQuery(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public GetMoviebyNameQueryVM Handle()
        {
            // Todo: Arama koşulları güncellenebilir
            var movie = _db.Movies.Include(x => x.Director).Include(x => x.Genre).Where(x => x.MovieName.ToLower().Trim().Contains(MovieName.ToLower().Trim()) && x.IsActive == true).FirstOrDefault();
            if (movie == null)
            {
                throw new InvalidOperationException("Aradığınız film bulunamadı");
            }
            GetMoviebyNameQueryVM vm = _mapper.Map<GetMoviebyNameQueryVM>(movie);
            vm.ActorNames = _db.MovieAndActors.Where(x => x.MovieId == movie.Id).Select(x => x.Actor.FullName).ToArray();
            return vm;
        }
    }
}
