using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonbook.Core.Contracts.People
{
   public interface IPersonRepository
    {

        Person Get(int Id);
        Person GetByEmail(string email);
        List<Person> GetAll();
        List<Person> GetActivePerson();
        void Delete(int Id);
        Person Add(Person person);
        Person GetPersonWithPhoneList(int Id);
        void SaveChange();

    }
}
