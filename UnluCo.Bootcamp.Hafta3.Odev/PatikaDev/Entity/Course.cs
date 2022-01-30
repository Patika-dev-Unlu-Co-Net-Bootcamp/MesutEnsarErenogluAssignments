

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatikaDev.Entity 
{
    public class Course : BaseEntity
    {
        [Required]
        [MaxLength(250, ErrorMessage = "Eğitim adı 250 karakterden uzun olamaz")]
        public string CourseName { get; set; }

        [MaxLength(250, ErrorMessage = "Eğitim açıklaması 500 karakterden uzun olamaz")]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public virtual IEnumerable<Instructor> Instructors { get; set; }
        public virtual IEnumerable<Assistant> Assistants { get; set; }
        public virtual IEnumerable<Attendee> Attendees { get; set; }
    }
}
