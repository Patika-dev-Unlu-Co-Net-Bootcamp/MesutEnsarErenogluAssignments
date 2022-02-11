
using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.CommandVMs;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands
{
    public class DeleteMovieCommand
    {
        private readonly AppDbContext _db;
        public int MovieId { get; set; }
        public DeleteMovieCommandVM Model { get; set; }

        public DeleteMovieCommand(AppDbContext db)
        {
            _db = db;
        }
        public void Handle()
        {
            var movie = _db.Movies.SingleOrDefault(x => x.Id == MovieId && x.IsActive == true);
            if (movie == null)
            {
                throw new InvalidOperationException("Aradığınız film bulunamadı!");
            }
            if (Model.IsActive)
            {
                throw new InvalidOperationException("Hatalı seçim yaptınız! Filmi silmek için yeniden deneyin!");
            }
            movie.IsActive = Model.IsActive;
            _db.SaveChanges();
        }
    }
}
