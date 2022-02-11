using System;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie
{
    public class UpdateMovieCommandVM
    {
        public string MovieName { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DirectorId { get; set; }
    }
}
