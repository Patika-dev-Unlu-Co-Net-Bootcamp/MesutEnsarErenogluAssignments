using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
