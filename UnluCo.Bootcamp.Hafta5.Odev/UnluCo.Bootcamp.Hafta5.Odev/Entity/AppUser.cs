
using System.ComponentModel.DataAnnotations;
using UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity;

namespace UnluCo.Bootcamp.Hafta2.Odev.Entity
{
    public class AppUser : BaseEntity
    {
       
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email adresi zorunludur!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre girişi zorunludur!")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Şifre doğrulaması zorunludur!")]
        [Compare("Password",ErrorMessage ="Girilen değer belirlediğiniz şifre ile uyuşmuyor!")]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "isim girişi zorunludur!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        public string LastName { get; set; }

        private string _fullname;
        public string FullName
        {
            get
            {
                if (FirstName != null && LastName != null)
                {
                    _fullname = $"{FirstName} {LastName}";
                }
                else
                {
                    _fullname = "Name Surname";
                }
                return _fullname;
            }
        }
    }
}
