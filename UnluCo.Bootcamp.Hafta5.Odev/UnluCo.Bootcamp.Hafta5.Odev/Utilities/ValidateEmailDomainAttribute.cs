using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bootcamp.Hafta2.Odev.Utilities
{
    public class ValidateEmailDomainAttribute : ValidationAttribute
    {
        /// <summary>
        /// This attribute checks whether the email entered by the user has one of the accepted domains in the project.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            var result = false;
            string[] acceptedDomains = { "gmail.com", "hotmail.com", "outlook.com" };
            string email = (string)value;
            var domain = email.Split("@");

            if (acceptedDomains.Contains(domain[1]))
            {
                result = true;
            }
            return result;
        }
    }
}
