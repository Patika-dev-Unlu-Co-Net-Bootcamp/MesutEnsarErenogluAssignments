using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Bootcamp.Hafta2.Odev.Utilities;

namespace UnluCo.Bootcamp.Hafta2.Odev.ViewModels.Account
{
    public class RegisterModel
    {
        [Required]
        //This attribute checks whether the email entered by the user has one of the accepted domains in the project.
        [ValidateEmailDomain(ErrorMessage ="Kaydolacağınız email adresi gmail,hotmail ya da outlook uzantılı olmalıdır.")] 
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
