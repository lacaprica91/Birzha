using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class EFCompanyRepository : ICompanyRepository
    {
        private ApplicationDbContext context;

        public EFCompanyRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Company> Companies => context.Companies;
    }
}
