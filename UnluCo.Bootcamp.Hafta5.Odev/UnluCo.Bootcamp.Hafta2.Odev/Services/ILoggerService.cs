using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bootcamp.Hafta2.Odev.Services
{
    public interface ILoggerService
    {
        public void Write(HttpContext context);
    }
}
