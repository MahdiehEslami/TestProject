using Microsoft.AspNetCore.Http;
using PhoneBook.Core.Entites.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.UI.WebMVC.Models.People
{
    public abstract class AddPersonViewModel
    {
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50,MinimumLength =2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public IFormFile Image { get; set; }
    }

    public class AddPersonDisplayViewModel:AddPersonViewModel
    {
        public List<Tag> TagForDisplay { get; set; }
        public List<int> oldTag { get; set; } 
    }

    public class AddPersonSelectViewModel: AddPersonViewModel
    {
        public List<int> SelectedTag { get; set; }
    }
}
