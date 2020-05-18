using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models.ViewModels
{
    public class CompaniesListViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
