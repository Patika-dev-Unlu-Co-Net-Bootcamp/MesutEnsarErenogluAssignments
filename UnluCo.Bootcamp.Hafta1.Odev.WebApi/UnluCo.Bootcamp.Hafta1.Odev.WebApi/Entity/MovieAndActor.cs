using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity
{
    public class MovieAndActor
    {
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
