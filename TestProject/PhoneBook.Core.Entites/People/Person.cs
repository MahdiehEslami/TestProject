using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entites.People
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string  Address { get; set; }
        public string Image { get; set; }
        public List<Phone> phones { get; set; }
        public List<PersonTag> tags { get; set; }
    }
}
