using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Context;
using UnluCo.Bootcamp.Hafta2.Odev.Application.AccountOperations.Commands;
using UnluCo.Bootcamp.Hafta2.Odev.Validators.Account;
using UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Account;

namespace UnluCo.Bootcamp.Hafta2.Odev.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public AccountController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Register([FromBody]RegisterModel Model)
        {
            RegisterCommand command = new RegisterCommand(_db,_mapper);
            command.Model = Model;
            RegisterCommandValidator validator = new RegisterCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel Model)
        {
            LoginCommand command = new LoginCommand(_db);
            command.Model = Model;
            command.Handle();
            return Ok();
        }
    }
}
