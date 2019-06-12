using Phonbook.Core.Contracts.Phones;
using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.DAL.EF.Phones
{
    public class EfPhoneRepository : IPhoneRepository
    {
        private readonly PhoneBookContext Context;

        public EfPhoneRepository(PhoneBookContext _Context)
        {
            Context = _Context;
        }
        public Phone Add(Phone phone)
        {
            Context.phones.Add(phone);
            Context.SaveChanges();
            return phone;
        }

        public void Delete(int Id)
        {
            Phone phones = new Phone
            {
                phoneId = Id
            };
            Context.phones.Remove(phones);
        }

        public Phone Get(int Id)
        {
            return Context.phones.Find(Id);
             
        }

        public List<Phone> GetAll()
        {
            return Context.phones.ToList();
        }
    }
}
