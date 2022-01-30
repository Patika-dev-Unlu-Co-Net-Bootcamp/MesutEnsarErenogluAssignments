

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaDev.Entity
{
    public class AchievementStatus : BaseEntity 
    {
        [Required]
        [ForeignKey("Attendee")]
        public int AttendeeId { get; set; }
        public virtual Attendee Attendee { get; set; }
        [Required]
        public DateTime GradeDate { get; set; }
        [Required]
        public double Grade { get; set; }
    }
}
