using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonbook.Core.Contracts.People
{
   public interface IPeopleService
    {
        Person GetPersonWithPhoneList(int Id);
        void DeletePerson(int Id);
       // Person AddPersonWithUniqEmail(Person person, String Email);
    }
}
