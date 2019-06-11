using PhoneBook.Core.Entites.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Entites.People
{
    public class PersonTag
    {
        public int PersonTagId { get; set; }
        public int TagId { get; set; }
        public int PersonId { get; set; }
        public Person person { get; set; }
        public Tag tag { get; set; }
    }
}
