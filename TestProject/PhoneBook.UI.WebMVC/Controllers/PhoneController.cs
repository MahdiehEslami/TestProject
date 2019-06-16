using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonbook.Core.Contracts.Phones;
using PhoneBook.Core.Entites.Phones;
using PhoneBook.UI.WebMVC.Models.Tags;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneRepository Repo;

        public PhoneController(IPhoneRepository phoneRepository)
        {
           Repo = phoneRepository;
        }
        public IActionResult Index()
        {
            List<Phone> phones = Repo.GetAll().ToList();
            return View(phones);
        }

     
    }
}
