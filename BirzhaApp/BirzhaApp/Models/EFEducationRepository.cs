using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class EFEducationRepository : IEducationRepository
    {
        private ApplicationDbContext context;

        public EFEducationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Education> Education => context.Education;
        
    }
}
