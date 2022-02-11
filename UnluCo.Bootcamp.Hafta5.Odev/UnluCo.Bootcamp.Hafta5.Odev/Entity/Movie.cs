using System;
using System.Collections.Generic;
using UnluCo.Bootcamp.Hafta2.Odev.Utilities;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity
{
    public class Movie : BaseEntity
    {
        [CustomSearchProperty]
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }

        public virtual IEnumerable<MovieAndActor> MovieAndActors { get; set; }
    }
}
