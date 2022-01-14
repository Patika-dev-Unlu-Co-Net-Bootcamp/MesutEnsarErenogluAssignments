using AutoMapper;
using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands
{
    public class CreateMovieCommand
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public CreateMovieCommandVM Model{ get; set; }
        public CreateMovieCommand(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _db.Movies.SingleOrDefault(x => x.MovieName.ToLower() == Model.MovieName.ToLower() && x.DirectorId == Model.DirectorId);
            ;
            if (movie != null)
            {
                throw new InvalidOperationException("Film kayıtlarda mevcuttur!");
            }
            if (_db.Directors.Any(x=>x.Id ==Model.DirectorId) == false)
            {
                throw new InvalidOperationException("Yönetmen kayıtlarımızda yer almıyor, öncelikle yönetmen girişi yapılmalıdır!");
            }
            if (_db.Genres.Any(x=>x.Id ==Model.GenreId) == false)
            {
                throw new InvalidOperationException("Kategori kayıtlarımızda yer almıyor, öncelikle kategori girişi yapılmalıdır!");
            }
            movie = _mapper.Map<Movie>(Model);

            _db.Movies.Add(movie);
            _db.SaveChanges();
        }


    }
}
