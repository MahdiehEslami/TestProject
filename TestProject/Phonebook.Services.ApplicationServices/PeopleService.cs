using Phonbook.Core.Contracts.People;
using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Services.ApplicationServices
{
    public class PeopleService : IPeopleService
    {
        private readonly IPersonRepository personRepo;

        public PeopleService(IPersonRepository personRepository)
        {
            personRepo = personRepository;
        }
        public void DeletePerson(int Id)
        {
            throw new NotImplementedException();
        }

        public Person GetPersonWithPhoneList(int Id)
        {
            throw new NotImplementedException(); 
            //return personRepo.Get(Id).phones.Exists()
            //.Include(c => c.phones).FirstOrDefault();
        }
    }
}
