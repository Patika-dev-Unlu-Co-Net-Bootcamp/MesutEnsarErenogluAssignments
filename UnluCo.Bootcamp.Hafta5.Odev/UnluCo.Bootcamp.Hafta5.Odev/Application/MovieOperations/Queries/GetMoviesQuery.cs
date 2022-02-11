using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public GetMoviesQuery(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<GetMoviesQueryVM> Handle()
        {
            
            var movielist = _db.Movies.Include(x=>x.Director).Include(x=>x.Genre).Include(x=>x.MovieAndActors).Where(x=>x.IsActive==true).OrderBy(x => x.MovieName).ToList();
            List<GetMoviesQueryVM> vm = _mapper.Map<List<GetMoviesQueryVM>>(movielist);
            // ToDo : Aşağıdaki kod yerine AutoMap içerisinde actor isimleri tanımı yapılabilmeli
            foreach (var item in vm)
            {
                item.ActorNames = _db.MovieAndActors.Where(x => x.Movie.MovieName == item.MovieName).Select(x => x.Actor.FullName).ToArray();
            }
            return vm;
        }
        

    }
}
