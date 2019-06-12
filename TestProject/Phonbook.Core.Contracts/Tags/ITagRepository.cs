using PhoneBook.Core.Entites.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonbook.Core.Contracts.Tags
{
    public interface ITagRepository
    {
        Tag Get(int id);
        List<Tag> GetAll();
        //void Delete(int id);
        Tag Add(Tag tag);
    }
}
