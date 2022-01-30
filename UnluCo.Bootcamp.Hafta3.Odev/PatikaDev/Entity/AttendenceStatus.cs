using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaDev.Entity
{
    public class AttendenceStatus : BaseEntity 
    {
        [Required]
        [ForeignKey("Attendee")]
        public int AttendeeId { get; set; }

        public virtual Attendee Attendee { get; set; }

        [Required]
        public DateTime CourseDate { get; set; }

        [Required]
        public bool IsAttended { get; set; }
    }
}
