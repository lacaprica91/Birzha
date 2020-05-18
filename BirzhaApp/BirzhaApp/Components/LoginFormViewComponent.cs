using BirzhaApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Components
{
    public class LoginFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new LoginModel());
        }
    }
}
