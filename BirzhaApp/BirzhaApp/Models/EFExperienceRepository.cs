using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class EFExperienceRepository : IExperienceRepository
    {
        private ApplicationDbContext context;

        public EFExperienceRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Experience> Experience => context.Experience;
    }
}
