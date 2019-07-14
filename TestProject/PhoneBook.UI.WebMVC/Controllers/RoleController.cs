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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel roleView)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                   Name=roleView.RoleName
                };
                var result = roleManager.CreateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }

            return View();
        }

        public IActionResult Delete(string Id)
        {
            var role = roleManager.FindByIdAsync(Id).Result;
            if (role!=null)
            {
                var result = roleManager.DeleteAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return NotFound();
        }

        public IActionResult Update(string Id)
        {
            var role = roleManager.FindByIdAsync(Id).Result;
            if (role != null)
            {
                RoleViewModel model = new RoleViewModel
                {
                    RoleName = role.Name
                };
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(string Id, RoleViewModel model)
        {
            var role = roleManager.FindByIdAsync(Id).Result;
            if (role!=null)
            {
                role.Name = model.RoleName;
                var result = roleManager.UpdateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return NotFound();
        }


    }
}
