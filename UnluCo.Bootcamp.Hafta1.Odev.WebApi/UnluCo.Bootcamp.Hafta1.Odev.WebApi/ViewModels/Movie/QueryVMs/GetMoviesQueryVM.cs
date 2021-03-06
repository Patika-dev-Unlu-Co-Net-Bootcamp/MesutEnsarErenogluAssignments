using System;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.ViewModels.Movie
{
    public class GetMoviesQueryVM
    {
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }
        public string[] ActorNames { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
