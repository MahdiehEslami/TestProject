using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.UI.WebMVC.Models.AAA
{
    public class UpdateUserViewModel
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

    }
    public class CreateUserViewModel:UpdateUserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string PassWord { get; set; }


    }
}
