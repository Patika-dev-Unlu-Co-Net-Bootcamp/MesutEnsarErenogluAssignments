using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev4.WebApi.Filter
{
    public class CustomResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            DateTime responseTime = DateTime.Now;
            context.HttpContext.Response.Headers.Add("ResponseTime", responseTime.ToString());
        }
    }
}
