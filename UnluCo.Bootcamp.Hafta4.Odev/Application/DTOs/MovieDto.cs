
using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class MovieDto : BaseDto
    {
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }
        public IEnumerable<DirectorDto> Directors { get; set; }
        public IEnumerable<ActorDto> Actors { get; set; }
    }
}
