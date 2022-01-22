using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;

namespace UnluCo.Bootcamp.Hafta2.Odev.Utilities
{
    public class CustomAuthAttribute : ActionFilterAttribute
    {
        
        private readonly AppDbContext _db;

        public CustomAuthAttribute(AppDbContext db)
        {
            _db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader) && string.IsNullOrWhiteSpace(authHeader))
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            authHeader = Convert.ToString(authHeader).Split(" ")[1];
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            var emailAndPassword = encoding.GetString(Convert.FromBase64String(authHeader)).Split(":");

            var user = _db.Users.SingleOrDefault(x => x.Email == emailAndPassword[0] && x.Password == emailAndPassword[1]);
            if (user == null)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }
            base.OnActionExecuting(context);
        }




    }
}
