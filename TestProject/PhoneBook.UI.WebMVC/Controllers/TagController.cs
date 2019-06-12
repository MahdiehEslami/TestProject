using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonbook.Core.Contracts.Tags;
using PhoneBook.Core.Entites.Tags;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository Repo;

        public TagController(ITagRepository tagRepository)
        {
            Repo = tagRepository;
        }
        public IActionResult Index()
        {
            List<Tag> tags = Repo.GetAll().ToList();
            return View(tags);
        }
    }
}
