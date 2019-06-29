using Phonbook.Core.Contracts.People;
using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.Services.ApplicationServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepo;

        public PersonService(IPersonRepository personRepository)
        {
            personRepo = personRepository;
        }

        public bool CheckUniqeEmail(string email)
        {
            var p = personRepo.GetByEmail(email);
            if (p != null)
            {
                return false;
            }
            return true;
                
        }

        public void DeletePerson(int Id)
        {
            
            var p = personRepo.GetPersonWithPhoneList(Id);

            if (p.phones.Any())
            {
                p.Status = false;
                personRepo.SaveChange();
            }


            else
            {
                personRepo.Delete(Id);
            }

        }
    }
}