using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirzhaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BirzhaApp.Models.ViewModels;
using BirzhaApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace BirzhaApp.Controllers
{
    public class CompanyController : Controller {
        private ICompanyRepository repository;
        public int PageSize = 1;

        public CompanyController(ICompanyRepository repo)
        {
            repository = repo;
        }

        [Authorize]
        public ViewResult List(int companyPage = 1)
                => View(new CompaniesListViewModel {
                    Companies = repository.Companies
                            .OrderBy(c => c.CompanyID)
                            .Skip((companyPage - 1) * PageSize)
                            .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = companyPage,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Companies.Count()
                    }
                });

    }
}