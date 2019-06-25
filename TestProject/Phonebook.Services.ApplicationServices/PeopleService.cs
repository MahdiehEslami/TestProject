using Phonbook.Core.Contracts.People;
using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Person person1 = personRepo.Get(Id);
            if (person1.phones!=null)
            {
                personRepo.Delete(Id);
            }
            else
            {
               
                Person person = new Person
                {
                    Status = false
                };
            }

        }

        public Person GetPersonWithPhoneList(int Id)
        {
            throw new NotImplementedException();

  
           
        }
    }
}
