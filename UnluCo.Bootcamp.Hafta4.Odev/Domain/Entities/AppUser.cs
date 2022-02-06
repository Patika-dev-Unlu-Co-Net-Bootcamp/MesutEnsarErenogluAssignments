
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class AppUser:IdentityUser
    {
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

        public Guid RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public int RoleId { get; set; }


    }
}
