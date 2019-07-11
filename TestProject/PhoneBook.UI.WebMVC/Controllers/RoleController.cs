using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.UI.WebMVC.Models.AAA;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }


    }
}
