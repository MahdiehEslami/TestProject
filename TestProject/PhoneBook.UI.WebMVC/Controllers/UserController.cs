using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.UI.WebMVC.Models.AAA;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.UI.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var User = userManager.Users.Take(50).ToList();
            return View(User);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName
                };
                var result = userManager.CreateAsync(user, model.PassWord).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("index");
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
            var user = userManager.FindByIdAsync(Id).Result;
            if (user != null)
            {
                var result = userManager.DeleteAsync(user).Result;
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
            var user = userManager.FindByIdAsync(Id).Result;
            if (user != null)
            {
                UpdateUserViewModel model = new UpdateUserViewModel
                {
                    UserName=user.UserName,
                    Email = user.Email
                };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(string Id, UpdateUserViewModel model)
        {
            var user = userManager.FindByIdAsync(Id).Result;
            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                var result = userManager.UpdateAsync(user).Result;
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
                return View(model);
            }
            return NotFound();
        }

    }


}

