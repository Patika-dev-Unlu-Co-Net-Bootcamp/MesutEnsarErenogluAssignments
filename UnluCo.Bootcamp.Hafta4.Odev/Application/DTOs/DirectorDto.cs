
using System.Collections.Generic;

namespace Application.DTOs
{
    public class DirectorDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string _fullname;
        public string FullName
        {
            get
            {
                if (FirstName != null && LastName != null)
                {
                    _fullname = $"{FirstName} {LastName}";
                }
                else
                {
                    _fullname = "Name Surname";
                }
                return _fullname;
            }
        }
        public virtual IEnumerable<MovieDto> Movies { get; set; }
    }
}
