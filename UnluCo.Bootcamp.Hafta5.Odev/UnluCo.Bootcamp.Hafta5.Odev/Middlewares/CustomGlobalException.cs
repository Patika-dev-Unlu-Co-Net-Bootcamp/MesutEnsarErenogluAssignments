using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using UnluCo.Bootcamp.Hafta2.Odev.Services;

namespace UnluCo.Bootcamp.Hafta2.Odev.Middlewares
{
    public class CustomGlobalException
    {
        private readonly RequestDelegate _next;

        public CustomGlobalException(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILoggerService _logger)
        {
            try
            {
                _logger.Write(context);
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await context.Response.WriteAsync(ex.Message);
                //context.Response.StatusCode = 401;
                _logger.Write(context);
            }
        }
    }
}
