using Phonbook.Core.Contracts.People;
using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.DAL.EF.People
{
    public class EfPersonRepository : IPersonRepository
    {
        private readonly PhoneBookContext context;

        public EfPersonRepository(PhoneBookContext _context)
        {
            context = _context;
        }
        public Person Add(Person person)
        {

            context.people.Add(person);
            context.SaveChanges();
            return person;
        }

        public void Delete(int Id)
        {
            Person person = new Person
            {
                PersonId = Id
            };
            context.people.Remove(person);

        }

        public Person Get(int Id)
        {
            return context.people.Find(Id);
        }

        public List<Person> GetAll()
        {
            return context.people.ToList();
        }
    }
}
