
using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Account;

namespace UnluCo.Bootcamp.Hafta2.Odev.Application.AccountOperations.Commands
{
    public class LoginCommand
    {
        private readonly AppDbContext _db;
        public LoginModel Model { get; set; }

        public LoginCommand(AppDbContext db)
        {
            _db = db;
        }
        public string Handle()
        {
            var user = _db.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user == null)
            {
                throw new InvalidOperationException("Email ve şifreniz hatalı!");
            }
            return user.FullName;
        }
    }
}
