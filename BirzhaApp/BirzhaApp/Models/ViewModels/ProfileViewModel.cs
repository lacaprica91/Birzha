using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models.ViewModels
{
    public class ProfileViewModel
    {
        public Education education;
        public Experience experience;
        public Volunteering volunteering;
        public User userDetails;
    }
}
