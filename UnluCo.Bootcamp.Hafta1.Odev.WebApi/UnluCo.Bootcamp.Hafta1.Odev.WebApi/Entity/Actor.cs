
using System.Collections.Generic;

namespace UnluCo.Bootcamp.Hafta1.Odev.WebApi.Entity
{
    public class Actor:BaseEntity
    {
        public string FirstName { get; set; }
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

        public virtual IEnumerable<MovieAndActor> MovieAndActors { get; set; }
    }
}
