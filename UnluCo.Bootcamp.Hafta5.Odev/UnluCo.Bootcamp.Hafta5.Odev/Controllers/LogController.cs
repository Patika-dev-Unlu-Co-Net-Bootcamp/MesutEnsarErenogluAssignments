using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;

namespace UnluCo.Bootcamp.Hafta2.Odev.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public LogController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetLogs()
        {
            var result = _db.Logs.ToList();
            return Ok(result);
        }
    }
}
