

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatikaDev.Entity
{
    public class Instructor:BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "İsim 50 karakterden fazla olamaz")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Soyisim 50 karakterden fazla olamaz")]
        public string LastName { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Email 50 karakterden fazla olamaz")]
        public string Email { get; set; }
    }
}
