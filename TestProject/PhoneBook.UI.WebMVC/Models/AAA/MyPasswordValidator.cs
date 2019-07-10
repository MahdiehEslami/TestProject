using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.UI.WebMVC.Models.AAA
{
    public class MyPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {

            List<IdentityError> errors = new List<IdentityError>();
            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "pasword is equal to user"
                });
            }
            return Task.FromResult(errors.Any() ?
                   IdentityResult.Failed(errors.ToArray()) :
                   IdentityResult.Success);
        }

    }

    public class MyPasswordValidatorFull : PasswordValidator<AppUser>
    {
        private readonly UserDbContext Usercontext;

        public MyPasswordValidatorFull(UserDbContext  context)
        {
            Usercontext = context;
        }
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var parentResult= base.ValidateAsync(manager, user, password).Result;
            List<IdentityError> errors = new List<IdentityError>();
            if (!parentResult.Succeeded)
            {
                errors = parentResult.Errors.ToList();
            }
            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "pasword is equal to user"
                });
            }
            if (Usercontext.BadPasswords.Any(c=>c.Password==password))
            {
                errors.Add(new IdentityError
                {
                    Code = "BadPassword",
                    Description = "Passsword is a BadPassword"
                });
            }
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success
                );

        }
        
    }
}
