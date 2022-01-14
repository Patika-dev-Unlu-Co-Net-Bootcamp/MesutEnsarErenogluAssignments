
using System.Collections.Generic;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Movie> Movies { get; set; }
    }
}
