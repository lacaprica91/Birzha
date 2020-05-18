using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class User : IdentityUser 
    {
        //add aditional properties as necessary
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Postcode")]
        public string PostCode { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Address line 1")]
        public string Address1 { get; set; }
        [Display(Name = "Address line 2")]
        public string Address2 { get; set; }
        [Display(Name = "Phone")]
        override public string PhoneNumber { get; set; }
    }
}
