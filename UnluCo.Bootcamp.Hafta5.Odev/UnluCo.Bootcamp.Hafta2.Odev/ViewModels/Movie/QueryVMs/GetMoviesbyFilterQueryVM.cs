

using System;

namespace UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Movie.QueryVMs
{
    public class GetMoviesbyFilterQueryVM
    {

        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }
        public string[] ActorNames { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
