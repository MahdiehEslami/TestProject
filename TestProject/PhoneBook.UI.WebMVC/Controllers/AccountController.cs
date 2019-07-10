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
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> manager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> manager,SignInManager<AppUser> signInManager)
        {
            this.manager = manager;
            this.signInManager = signInManager;
        }
        // GET: /<controller>/
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });

            //LoginViewModel model = new LoginViewModel();
            //model.ReturnUrl = ReturnUrl;
            //return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await manager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                     user = manager.FindByEmailAsync(model.UserName).Result;
                }
                if (user!=null)
                {
                    await signInManager.SignOutAsync();
                    if(( await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model?.ReturnUrl ?? "/");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(model);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
