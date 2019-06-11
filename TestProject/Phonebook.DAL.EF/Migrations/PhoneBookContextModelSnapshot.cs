﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phonebook.DAL.EF;

namespace Phonebook.DAL.EF.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    partial class PhoneBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneBook.Core.Entites.People.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Image")
                        .IsUnicode(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PersonId");

                    b.ToTable("people");
                });

            modelBuilder.Entity("PhoneBook.Core.Entites.People.PersonTag", b =>
                {
                    b.Property<int>("PersonTagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId");

                    b.Property<int>("TagId");

                    b.HasKey("PersonTagId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TagId");

                    b.ToTable("personTags");
                });

            modelBuilder.Entity("PhoneBook.Core.Entites.Phones.Phone", b =>
                {
                    b.Property<int>("phoneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PersonId");

                    b.Property<int>("PhoneType");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("phoneId");

                    b.HasIndex("PersonId");

                    b.ToTable("phones");
                });

            modelBuilder.Entity("PhoneBook.Core.Entites.Tags.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("TagId");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("PhoneBook.Core.Entites.People.PersonTag", b =>
                {
                    b.HasOne("PhoneBook.Core.Entites.People.Person", "person")
                        .WithMany("tags")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhoneBook.Core.Entites.Tags.Tag", "tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhoneBook.Core.Entites.Phones.Phone", b =>
                {
                    b.HasOne("PhoneBook.Core.Entites.People.Person")
                        .WithMany("phones")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
