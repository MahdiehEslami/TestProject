using Microsoft.EntityFrameworkCore;
using Phonebook.DAL.EF.People;
using Phonebook.DAL.EF.Phones;
using Phonebook.DAL.EF.Tags;
using PhoneBook.Core.Entites.People;
using PhoneBook.Core.Entites.Phones;
using PhoneBook.Core.Entites.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.DAL.EF
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<PersonTag> personTags { get; set; }
        public DbSet<Phone> phones { get; set; }
        public DbSet<Tag> tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PhoneBookFinaly;Integrated Security=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PhoneConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonTagConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());

        }
    }
}
