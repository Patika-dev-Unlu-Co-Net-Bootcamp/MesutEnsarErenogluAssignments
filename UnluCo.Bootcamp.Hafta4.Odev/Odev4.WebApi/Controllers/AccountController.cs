
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Odev4.WebApi.Models.User;
using Odev4.WebApi.Token;
using System.Threading.Tasks;

namespace Odev4.WebApi.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;
        private readonly UserManager<AppUser> _userManager;

        
        private readonly IMapper _mapper;

        public AccountController(TokenGenerator tokenGenerator, UserManager<AppUser> userManager, IMapper mapper)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bilgiler eksik");
            }
            var user = await _userManager.FindByEmailAsync(userRegisterModel.Email);
            if (user != null)
            {
                return BadRequest("Kullanıcı zaten mevcut");

            }
            AppUser appUser = new AppUser();
            appUser.Email = userRegisterModel.Email;
            appUser.FirstName = userRegisterModel.FirstName;
            appUser.LastName = userRegisterModel.LastName;
            appUser.UserName = userRegisterModel.Email;
            var result = await _userManager.CreateAsync(appUser, userRegisterModel.Password);
            var roleResult = await _userManager.AddToRoleAsync(appUser, "user");

            if (result.Succeeded && roleResult.Succeeded)
            {
                return Ok("Kullanıcı kaydı başarılı");
            }
            else
            {
                return BadRequest("Kayıt tamamlanamadı");
            }
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AppUserLoginModel userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bilgiler eksik");
            }
            var user = await _userManager.FindByEmailAsync(userLoginModel.Email);
            if (user==null)
            {
                return BadRequest("Böyle bir kullanıcı yok");
            }
            var result = await _userManager.CheckPasswordAsync(user,userLoginModel.Password);
            if (result)
            {
                var token = _tokenGenerator.CreateToken(user);
                return Ok(token);
            }
            else
            {
                return BadRequest("İşlem Başarısız");
            }
        }
        

            
     }
}
