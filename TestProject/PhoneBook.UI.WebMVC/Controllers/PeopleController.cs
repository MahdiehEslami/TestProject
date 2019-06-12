using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonbook.Core.Contracts.People;
using Phonbook.Core.Contracts.Tags;
using PhoneBook.Core.Entites.People;
using PhoneBook.UI.WebMVC.Models.People;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository Personrepo;
        private readonly ITagRepository TagRepo;

        public PeopleController(IPersonRepository personRepository,ITagRepository tagRepository)
        {
            Personrepo = personRepository;
            TagRepo = tagRepository;
        }

        public IActionResult List()
        {
            List<Person> person = Personrepo.GetAll().ToList();
            return View(person);
        }

        public IActionResult Add()
        {
            AddPersonDisplayViewModel model = new AddPersonDisplayViewModel();
            model.TagForDisplay = TagRepo.GetAll().ToList();
            return View(model);
        }
    }
}
