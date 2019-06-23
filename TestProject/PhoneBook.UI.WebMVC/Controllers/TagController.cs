using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonbook.Core.Contracts.Tags;
using PhoneBook.Core.Entites.Tags;
using PhoneBook.UI.WebMVC.Models.Tags;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository tagRepo;

        public TagController(ITagRepository tagRepository)
        {
            tagRepo = tagRepository;
        }
        public IActionResult List()
        {
            List<Tag> Gettags = tagRepo.GetAll().ToList();
            AddTagViewModel model = new AddTagViewModel
            {
                tags= Gettags
            };
            
            return View(model);
        }


        [HttpPost]
        public IActionResult Add(AddTagViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model?.Title?.Length > 0)
                {
                    Tag tags = new Tag
                    {
                        Title = model.Title
                    };
                    tagRepo.Add(tags);
                    return RedirectToAction("list");
                }
                
             
            }

            return View();
        }
    }
}
