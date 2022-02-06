

using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Movie: BaseEntity
    {
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual IList<Genre> Genres { get; set; }
        public virtual IList<Director> Directors { get; set; }
        public virtual IList<Actor> Actors { get; set; }

    }
}
