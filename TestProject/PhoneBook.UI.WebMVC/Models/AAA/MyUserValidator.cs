using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.UI.WebMVC.Models.AAA
{
    public class MyUserValidator : IUserValidator<AppUser>
    {
        Task<IdentityResult> IUserValidator<AppUser>.ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (!user.Email.EndsWith("@Nikamooz"))
            {
                errors.Add(new IdentityError
                {
                    Code = "User",
                    Description = "Email is not Corect"
                });
            }
            return Task.FromResult(errors.Any() ?
                   IdentityResult.Failed(errors.ToArray()) :
                   IdentityResult.Success);
        }
    }
}
