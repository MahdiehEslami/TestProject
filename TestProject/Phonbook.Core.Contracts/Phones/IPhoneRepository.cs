using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonbook.Core.Contracts.Phones
{
    public interface IPhoneRepository
    {
        Phone Get(int Id);
        List<Phone> GetAll();
        void Delete(int Id);
        Phone Add(Phone phone);

    }
}
