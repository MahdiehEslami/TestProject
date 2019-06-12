using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonbook.Core.Contracts.People;
using PhoneBook.Core.Entites.People;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository repo;

        public PeopleController(IPersonRepository personRepository)
        {
            repo = personRepository;
        }
        public IActionResult List()
        {
            List<Person> person = repo.GetAll().ToList();
            return View(person);
        }
    }
}
