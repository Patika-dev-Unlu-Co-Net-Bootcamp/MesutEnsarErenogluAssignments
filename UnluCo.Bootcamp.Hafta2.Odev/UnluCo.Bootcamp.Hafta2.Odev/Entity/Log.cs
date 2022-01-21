using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bootcamp.Hafta2.Odev.Entity
{
    public class Log
    {
        public Log()
        {
            CreatedTime = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Method { get; set; }
        public DateTime CreatedTime { get; set; }
        public string RequestPath { get; set; }
        public int ResponseCode { get; set; }
        
    }
}
