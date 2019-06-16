using Microsoft.AspNetCore.Http;
using PhoneBook.Core.Entites.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.UI.WebMVC.Models.Tags
{
    public class AddTagViewModel
{
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }
    }
}

