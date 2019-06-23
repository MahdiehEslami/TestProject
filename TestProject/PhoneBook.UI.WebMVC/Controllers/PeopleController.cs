using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonbook.Core.Contracts.People;
using Phonbook.Core.Contracts.Phones;
using Phonbook.Core.Contracts.Tags;
using PhoneBook.Core.Entites.People;
using PhoneBook.Core.Entites.Tags;
using PhoneBook.UI.WebMVC.Models.People;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository PersonRepo;
        private readonly ITagRepository TagRepo;


        public PeopleController(IPersonRepository personRepository,ITagRepository tagRepository)
        {
            PersonRepo = personRepository;
            TagRepo = tagRepository;

        }

        public IActionResult List()
        {
            List<Person> person = PersonRepo.GetAll().ToList();
            return View(person);
        }

        public IActionResult Add()
        {
            AddPersonDisplayViewModel model = new AddPersonDisplayViewModel();
            model.TagForDisplay = TagRepo.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddPersonSelectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    tags = new List<PersonTag>(model.SelectedTag.Select(c => new PersonTag
                    {
                        TagId = c
                    }).ToList())

                };
                if (model?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.Image.CopyTo(ms);
                        var fileByte = ms.ToArray();
                        person.Image = Convert.ToBase64String(fileByte);
                    }
                }

               
                PersonRepo.Add(person);
                return RedirectToAction("List");
            }

            List<Tag> oldTagfind = new List<Tag>();
            foreach (int item in model.SelectedTag)
            {
                var t = TagRepo.Get(item);
                oldTagfind.Add(t);
            }
            AddPersonDisplayViewModel displayViewModel = new AddPersonDisplayViewModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                oldTag = oldTagfind
            };
            displayViewModel.TagForDisplay = TagRepo.GetAll().ToList();
            return View(displayViewModel);
        }

        public IActionResult Detail([FromRoute]int id)
        {
             var person = PersonRepo.GetPersonWithPhoneList(id);
            return View(person);
        }

        public IActionResult Delete([FromRoute]int Id)
        {
            PersonRepo.Delete(Id);
            return RedirectToAction("List");
        }
    }
}
