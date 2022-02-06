
using System.ComponentModel.DataAnnotations;

namespace Odev4.WebApi.Models.User
{
    public class AppUserRegisterModel
    {
        [Required(ErrorMessage = "isim girişi zorunludur!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "email boş geçilemez")]
        [EmailAddress(ErrorMessage = "email formatında bir adres giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "şifre boş geçilemez")]
        public string Password { get; set; }

        [Required(ErrorMessage = "şifre (tekrar) boş geçilemez")]
        [Compare("Password", ErrorMessage = "şifreler uymuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
