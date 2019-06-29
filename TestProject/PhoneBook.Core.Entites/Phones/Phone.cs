using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entites.Phones
{
    public class Phone
    {
        public int phoneId { get; set; }
        public string  phoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
        public int PersonId { get; set; }
    }
}
