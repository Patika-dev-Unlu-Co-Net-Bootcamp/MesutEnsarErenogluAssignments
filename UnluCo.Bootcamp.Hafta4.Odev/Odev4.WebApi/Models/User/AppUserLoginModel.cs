

using System.ComponentModel.DataAnnotations;

namespace Odev4.WebApi.Models.User
{
    public class AppUserLoginModel
    {
        [Required(ErrorMessage = "email boş geçilemez")]
        [EmailAddress(ErrorMessage = "email formatında bir adres giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "şifre boş geçilemez")]
        public string Password { get; set; }
    }
}
