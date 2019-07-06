using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonbook.Core.Contracts.Phones;
using PhoneBook.Core.Entites.Phones;
using PhoneBook.UI.WebMVC.Models.Phones;
using PhoneBook.UI.WebMVC.Models.Tags;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneRepository PhoneRepo;

        public PhoneController(IPhoneRepository phoneRepository)
        {
           PhoneRepo = phoneRepository;
        }
        public IActionResult Add([FromRoute]int id)
        {
            AddPhoneViewModel model = new AddPhoneViewModel();
            model.PersonId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddPhoneViewModel model,[FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                Phone phone = new Phone
                {
                   
                    phoneNumber = model.Number,
                    PhoneType = model.Type,
                    phoneId=id
                };
                PhoneRepo.Add(phone);
                return RedirectToAction("Detail", "People");
                
            }
            else
                return View(model);
        }

    }
}
