

using System.Collections.Generic;

namespace Application.DTOs
{
    public class GenreDto : BaseDto
    {
        public string Name { get; set; }
        public virtual IEnumerable<MovieDto> Movies { get; set; }
    }
}
