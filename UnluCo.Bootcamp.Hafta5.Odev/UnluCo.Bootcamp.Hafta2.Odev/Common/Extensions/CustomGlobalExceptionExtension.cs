using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Bootcamp.Hafta2.Odev.Middlewares;

namespace UnluCo.Bootcamp.Hafta2.Odev.Common.Extensions
{
    public static class CustomGlobalExceptionExtension
    {
        public static IApplicationBuilder UseCustomGlobalException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomGlobalException>();
        }
    }
}
