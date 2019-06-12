using Phonbook.Core.Contracts.Tags;
using PhoneBook.Core.Entites.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook.DAL.EF.Tags
{
    public class EfTagRepository:ITagRepository
    {
        private readonly PhoneBookContext Context;

        public EfTagRepository(PhoneBookContext _context)
        {
            Context = _context;
        }

        public Tag Add(Tag tag)
        {
            Context.tags.Add(tag);
            Context.SaveChanges();
            return (tag);

        }

        public Tag Get(int id)
        {
          return Context.tags.Find(id);
        }

        public List<Tag> GetAll()
        {
            return Context.tags.ToList();
        }
    }
}
