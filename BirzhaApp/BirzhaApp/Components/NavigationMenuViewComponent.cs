using BirzhaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private ICompanyRepository repository;

        public NavigationMenuViewComponent(ICompanyRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View( repository.Companies
                .Select(x => x.CompanyID)
                .OrderBy(x => x));
        }
    }
}
