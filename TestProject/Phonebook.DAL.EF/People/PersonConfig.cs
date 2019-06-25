using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Core.Entites.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.DAL.EF.People
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(256).IsUnicode(false).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(500);
            builder.Property(c => c.Image).IsUnicode();
            builder.Property(c => c.Status).IsRequired().HasDefaultValue(value: 1);

        }
    }
}
