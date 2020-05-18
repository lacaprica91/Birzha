using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class EFJobTypeRepository : IJobTypeRepository
    {
        private ApplicationDbContext context;

        public EFJobTypeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<JobType> JobTypes => context.JobTypes;
    }
}
