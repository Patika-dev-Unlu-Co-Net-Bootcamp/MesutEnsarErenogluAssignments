using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie.CommandVMs;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands
{
    public class AddActorstoMovieCommand
    {
        private readonly AppDbContext _db;
        public int MovieId { get; set; }
        public AddActorstoMovieCommandVM Model { get; set; }
        public AddActorstoMovieCommand(AppDbContext db)
        {
            _db = db;
        }
        public void Handle()
        {
            var movie = _db.Movies.SingleOrDefault(x => x.Id == MovieId && x.IsActive == true);
            if (movie == null)
            {
                throw new InvalidOperationException("Güncelleme yapmak istediğiniz film bulunamadı!");
            }
            foreach (var actorId in Model.ActorIds)
            {
                if (actorId <= 0)
                {
                    throw new InvalidOperationException("Eklemek istediğiniz oyuncu bulunamadı!");
                }
                var actor = _db.Actors.SingleOrDefault(x => x.Id == actorId && x.IsActive == true);
                if (actor == null)
                {
                    throw new InvalidOperationException("Eklemek istediğiniz oyuncu bulunamadı!");
                }
                
            }
            var movieandActors = _db.MovieAndActors.Include(x => x.Movie).Include(x => x.Actor).Where(x => x.Movie.Id == MovieId).ToList();
            foreach (var movieandActor in movieandActors)
            {
                if (Model.ActorIds.Contains(movieandActor.ActorId))
                {
                    throw new InvalidOperationException("Eklemek istediğiniz oyuncu filmin oyuncuları arasında yer alıyor!");
                }
            }
            foreach (var actorId in Model.ActorIds)
            {
                MovieAndActor movieAndActor = new MovieAndActor();
                movieAndActor.MovieId = movie.Id;
                movieAndActor.ActorId = actorId;
                _db.MovieAndActors.Add(movieAndActor);
                _db.SaveChanges();
            }
            
        }

    }
}
