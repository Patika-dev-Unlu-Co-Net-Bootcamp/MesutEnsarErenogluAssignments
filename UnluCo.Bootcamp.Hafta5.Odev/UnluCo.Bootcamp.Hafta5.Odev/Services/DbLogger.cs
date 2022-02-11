using Microsoft.AspNetCore.Http;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta2.Odev.Entity;

namespace UnluCo.Bootcamp.Hafta2.Odev.Services
{
    public class DbLogger : ILoggerService
    {
        private readonly AppDbContext _db;

        public DbLogger(AppDbContext db)
        {
            _db = db;
        }

        public void Write(HttpContext context)
        {
            Log log = new Log();
            log.Method = context.Request.Method;
            log.RequestPath = context.Request.Path;
            if (context.Response.StatusCode != 0)
            {
                log.ResponseCode = context.Response.StatusCode;
            }
            _db.Logs.Add(log);
            _db.SaveChanges();
        }
    }
}
