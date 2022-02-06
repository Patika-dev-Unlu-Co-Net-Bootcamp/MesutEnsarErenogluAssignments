using Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Odev4.WebApi.Models.Movie
{
    public class CreateMovieModel
    {
        [Required]
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int[] GenreIds { get; set; }
        public int[] DirectorIds { get; set; }
        public int[] ActorIds { get; set; }
    }
}
