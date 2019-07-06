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
}
