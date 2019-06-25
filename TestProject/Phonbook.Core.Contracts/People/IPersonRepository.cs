using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonbook.Core.Contracts.People
{
   public interface IPersonRepository
    {

        Person Get(int Id);
        List<Person> GetAll();
        void Delete(int Id);
        Person Add(Person person);
        Person GetPersonWithPhoneList(int Id);
    }
}
