

using System.Collections.Generic;

namespace Domain.Entities
{
    public class Genre: BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Movie> Movies { get; set; }
    }
}
