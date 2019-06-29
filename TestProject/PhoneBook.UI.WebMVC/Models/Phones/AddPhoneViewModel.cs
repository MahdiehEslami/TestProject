using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBook.Core.Entites.Phones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.UI.WebMVC.Models.Phones
{
    public class AddPhoneViewModel
    {
        public int PersonId { get; set; }
        [Required]
        [MinLength(7),MaxLength(12)]
        public string Number { get; set; }
        public PhoneType Type { get; set; }

        public List<SelectListItem> PhoneTypes { get; set; }

        public AddPhoneViewModel()
        {
            PhoneTypes = new List<SelectListItem>();
            PhoneTypes.Add(new SelectListItem
            {
                Value =((int)PhoneType.Home).ToString(),
                Text = PhoneType.Home.ToString()
            });
            PhoneTypes.Add(new SelectListItem
            {
                Value =((int)PhoneType.Mobile).ToString(),
                Text = PhoneType.Mobile.ToString()
            });
            PhoneTypes.Add(new SelectListItem
            {
                Value = ((int)PhoneType.Work).ToString(),
                Text = PhoneType.Work.ToString()
            });
            PhoneTypes.Add(new SelectListItem
            {
                Value =((int)PhoneType.Other).ToString(),
                Text = PhoneType.Other.ToString()
            });
        }
    }
}

