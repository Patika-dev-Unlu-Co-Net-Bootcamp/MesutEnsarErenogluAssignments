using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Application.MovieOperations.Commands
{
    public class DeleteMoviePermanentlyCommand
    {
        private readonly AppDbContext _db;
        public int MovieId { get; set; }
        public DeleteMoviePermanentlyCommand(AppDbContext db)
        {
            _db = db;
        }
        public void Handle()
        {
            var movie = _db.Movies.SingleOrDefault(x => x.Id == MovieId && x.IsActive == true);
            if (movie == null)
            {
                throw new InvalidOperationException("Silinmek istenen film bulunmadı!");
            }
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }

    }
}
