
using AutoMapper;
using System;
using System.Linq;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta2.Odev.Entity;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Account;

namespace UnluCo.Bootcamp.Hafta2.Odev.Application.AccountOperations.Commands
{
    public class RegisterCommand
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public RegisterModel Model { get; set; }

        public RegisterCommand(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void Handle()
        {
            if (_db.Users.Any(x=>x.Email == Model.Email))
            {
                throw new InvalidOperationException("Kayıtlı kullanıcı bulunmaktadır!");
            }
            var user = _mapper.Map<AppUser>(Model);
            if (user.UserName == null)
            {
                user.UserName = user.Email;
            }
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}
